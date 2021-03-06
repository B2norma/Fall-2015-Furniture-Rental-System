﻿using System.Collections.Generic;
using FurnitureRentalStore.DAL.Repository;
using FurnitureRentalStore.Model;

namespace FurnitureRentalStore.Controller
{
    /// <summary>
    /// This class is a Controller to connect Employee with the Form.
    /// </summary>
    class EmployeeController
    {

        private readonly EmployeeRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        public EmployeeController()
        {
            this.repository = new EmployeeRepository();
        }

        public void Add(Employee anEmployee)
        {
            this.repository.Add(anEmployee);
        }

        public void DeleteEmployee(int employeeID)
        {
            this.repository.Delete(employeeID);
        }

        public Employee GetEmployeeByID(int employeeID)
        {
            return this.repository.GetById(employeeID);
        }

        public void UpdateEmployee(Employee anEmployee)
        {
            this.repository.UpdateEmployee(anEmployee);
        }

        public List<Employee> GetAllEmployees()
        {
            return this.repository.GetAll();
        }

        public List<Employee> GetEmployeeForLogIn(string username, string password)
        {
            return this.repository.GetEmployeeForLogIn(username, password);
        }
    }
}
