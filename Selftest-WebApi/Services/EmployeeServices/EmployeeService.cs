using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Selftest_WebApi.Data;
using Selftest_WebApi.DTO.EmployerDTO;
using Selftest_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace Selftest_WebApi.Services.EmployeeServices
{
    public class EmployeeService : IEmployeeService
    {
        public List<EmployeeModel> employee = new List<EmployeeModel>
        {
            new EmployeeModel(),
            
        };
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public EmployeeService(IMapper mapper,DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<EmployeeServiceResponse<List<GetEmployeeDTO>>> AddNewEmp(AddEmployeeDTO newemp)
        {
            EmployeeServiceResponse<List<GetEmployeeDTO>> employeeservice = new EmployeeServiceResponse<List<GetEmployeeDTO>>();
            EmployeeModel e = _mapper.Map<EmployeeModel>(newemp);
            //e.id = employee.Max(cid => cid.id) + 1;  
            //employee.Add(e);

            await _context.Employees.AddAsync(e);
            await _context.SaveChangesAsync();

            employeeservice.Data= (_context.Employees.Select(c => _mapper.Map<GetEmployeeDTO>(c))).ToList();
            return employeeservice;    
        } 

        public async Task<EmployeeServiceResponse<GetEmployeeDTO>> getSingleEmp(int id)
        {
            EmployeeServiceResponse<GetEmployeeDTO> employeeservice=new EmployeeServiceResponse<GetEmployeeDTO>();
            EmployeeModel dbcontextemp = await _context.Employees.FirstOrDefaultAsync(ei => ei.id == id);
            employeeservice.Data = _mapper.Map<GetEmployeeDTO>(dbcontextemp);
            return employeeservice;
        }

        public async Task<EmployeeServiceResponse<List<GetEmployeeDTO>>> getvalue()
        {
            EmployeeServiceResponse<List<GetEmployeeDTO>> employeeservice = new EmployeeServiceResponse<List<GetEmployeeDTO>>();
            List<EmployeeModel> dbcontextemp = await _context.Employees.ToListAsync();
            employeeservice.Data = (dbcontextemp.Select(c => _mapper.Map<GetEmployeeDTO>(c))).ToList(); 
            return employeeservice;
        }

        public async Task<EmployeeServiceResponse<List<GetEmployeeDTO>>> DeleteEmployeeByID(int id)
        {
            EmployeeServiceResponse<List<GetEmployeeDTO>> employeeservice = new EmployeeServiceResponse<List<GetEmployeeDTO>>();
            try
            {
                EmployeeModel emp= await _context.Employees.FirstAsync(e => e.id == id);

                _context.Employees.Remove(emp);
                await _context.SaveChangesAsync();

                employeeservice.Data =(_context.Employees.Select(x => _mapper.Map<GetEmployeeDTO>(x))).ToList();


            }catch(Exception ex)
            {
                employeeservice.Success = false;
                employeeservice.Message = ex.Message;
            }
            return employeeservice;
        }

        public async Task<EmployeeServiceResponse<GetEmployeeDTO>> UpdateEmployeeInfo(UpdateEmployeeDto updateEmployee)
        {
            EmployeeServiceResponse<GetEmployeeDTO> employeeservice = new EmployeeServiceResponse<GetEmployeeDTO>();
            try
            {
                EmployeeModel emp = await _context.Employees.FirstOrDefaultAsync(x => x.id == updateEmployee.id);

                emp.ename=updateEmployee.ename;
                emp.econtact = updateEmployee.econtact;
                emp.esallary = updateEmployee.esallary;

                _context.Employees.Update(emp);
                await _context.SaveChangesAsync();

                employeeservice.Data = _mapper.Map<GetEmployeeDTO>(emp);

            }catch(Exception ex)
            {
                employeeservice.Success = false;
                employeeservice.Message = ex.Message;
            }
            return employeeservice;
        }
    }
}
