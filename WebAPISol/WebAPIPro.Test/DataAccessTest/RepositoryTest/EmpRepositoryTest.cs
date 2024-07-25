using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIPro.Models;
using WebAPIPro.Test.DataAccessTest.RepositoryTest;

namespace WebAPIPro.Test.DataAccessTest.RepositoryTest
{
    [TestClass]
    public class EmpRepositoryTest
    {
        [TestMethod]
        public async Task TestInsertEmployee()
        {
            // Arrange
            Employee emp = new Employee()
            {
                EmpId = 1001,
                EName = "Kiran",
                Password = "12345",
                Gender = "Male",
                Phone = "9876543211",
                Email = "kiran@gmail.com",
                Salary = 25000,
                Address = "Hyd",
                DeptNo = 20
            };
            EmpRepository obj = new EmpRepository();

            // Act
            var ActualRes = await obj.InsertEmployee(emp);

            // Assert
            Assert.AreEqual(1, ActualRes);
            Assert.AreEqual(1, obj.TotalRecords());
            Assert.IsNotNull(obj._db);
            Assert.AreEqual(emp.EmpId, (await obj.GetEmployeeByEmpId(emp.EmpId)).EmpId);
        }

        [TestMethod]
        public async Task TestUpdateEmployee()
        {
            // Arrange
            Employee Iemp = new Employee()
            {
                EmpId = 1001,
                EName = "Kiran",
                Password = "12345",
                Gender = "Male",
                Phone = "9876543211",
                Email = "kiran@gmail.com",
                Salary = 25000,
                Address = "Hyd",
                DeptNo = 20
            };            
            Employee emp = new Employee()
            {
                EmpId = 1001,
                EName = "KiranKumar",
                Password = "123455",
                Gender = "Male",
                Phone = "9876543211",
                Email = "kiranK@gmail.com",
                Salary = 25900,
                Address = "Hyd",
                DeptNo = 20
            };
            EmpRepository obj = new EmpRepository();
            await obj.InsertEmployee(Iemp);

            // Act
            var ActualRes = await obj.UpdateEmployee(emp);

            // Assert
            Assert.AreEqual(1, ActualRes);
            Assert.AreEqual(1, obj.TotalRecords());
            Assert.IsNotNull(obj._db);
            Assert.AreEqual(emp.EmpId, (await obj.GetEmployeeByEmpId(emp.EmpId)).EmpId);
            Assert.AreEqual(emp.Email, (await obj.GetEmployeeByOnlyEmail(emp.Email)).Email);
        }

        [TestMethod]
        public async Task TestDeleteEmployee()
        {
            // Arrange
            Employee emp1 = new Employee()
            {
                EmpId = 1001,
                EName = "Kiran",
                Password = "12345",
                Gender = "Male",
                Phone = "9876543211",
                Email = "kiran@gmail.com",
                Salary = 25000,
                Address = "Hyd",
                DeptNo = 20
            };
            Employee emp2 = new Employee()
            {
                EmpId = 1001,
                EName = "KiranKumar",
                Password = "123455",
                Gender = "Male",
                Phone = "9876543211",
                Email = "kiranK@gmail.com",
                Salary = 25900,
                Address = "Hyd",
                DeptNo = 20
            };
            EmpRepository obj = new EmpRepository();
            await obj.InsertEmployee(emp1);
            await obj.InsertEmployee(emp2);

            // Act
            var ActualRes = await obj.DeleteEmployee(emp1.EmpId);

            // Assert
            Assert.AreEqual(1, ActualRes);
            Assert.AreEqual(1, obj.TotalRecords());
            Assert.IsNotNull(obj._db);           
        }

        [TestMethod]
        public async Task TestAllEmployee()
        {
            // Arrange
            Employee emp1 = new Employee()
            {
                EmpId = 1001,
                EName = "Kiran",
                Password = "12345",
                Gender = "Male",
                Phone = "9876543211",
                Email = "kiran@gmail.com",
                Salary = 25000,
                Address = "Hyd",
                DeptNo = 20
            };
            Employee emp2 = new Employee()
            {
                EmpId = 1001,
                EName = "KiranKumar",
                Password = "123455",
                Gender = "Male",
                Phone = "9876543211",
                Email = "kiranK@gmail.com",
                Salary = 25900,
                Address = "Hyd",
                DeptNo = 20
            };
            EmpRepository obj = new EmpRepository();
            await obj.InsertEmployee(emp1);
            await obj.InsertEmployee(emp2);

            // Act
            var ActualRes = await obj.AllEmployees();

            // Assert            
            Assert.IsNotNull(obj._db);
            Assert.AreEqual(2, ActualRes.Count);
        }
    }
}
