﻿using System.Data;

namespace SalesWebMvc.Models {
    public class Seller {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DataSetDateTime BirthDate { get; set; }
        public double Salary { get; set; }
        public Department Department { get; set; }
        public ICollection<SalesRecord> Sales { get; set; }

        public Seller() {
        }

        public Seller(int id, string name, string email, DataSetDateTime birthDate, double salary, Department department) {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Salary = salary;
            Department = department;
        }

        public void AddSales(SalesRecord sr) {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr) {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final) {
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount);
        }
    }
}