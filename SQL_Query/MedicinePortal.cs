using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Hospital_Management.Models;
using System.Web.Mvc;

namespace Hospital_Management.SQL_Query
{
    public class MedicinePortal
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<SelectListItem> getAllMedicinesName()
        {
            DataTable dataTable = new DataTable();
            List<SelectListItem> list = new List<SelectListItem>();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from medicine";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
            }
            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow row = dataTable.Rows[i];
                string name = row[1].ToString();
                SelectListItem temp = new SelectListItem() { Text = name, Value = i.ToString() };
                list.Add(temp);
            }
            return list;
        }

        public List<Medicine>selectAll()
        {
            List<Medicine> medicines= new List<Medicine>();
            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from medicine";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
            }
            for(int i=0;i<dataTable.Rows.Count;i++)
            {
                DataRow row = dataTable.Rows[i];
                Medicine medicine = new Medicine
                {
                    id = Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    stock = Convert.ToInt32(row[2].ToString()),
                    price = Convert.ToDecimal(row[3].ToString()),
                    brand = row[4].ToString()
                };
                medicines.Add(medicine);
            }
            return medicines;
        }
        public Medicine select(int id)
        {

            DataTable dataTable = new DataTable();
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "select * from medicine where id=" + id;
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, conn);
                sqlDataAdapter.Fill(dataTable);
                DataRow row = dataTable.Rows[0];
                Medicine medicine = new Medicine
                {
                    id= Convert.ToInt32(row[0].ToString()),
                    name = row[1].ToString(),
                    stock = Convert.ToInt32(row[2].ToString()),
                    price=Convert.ToDecimal(row[3].ToString()),
                    brand=row[4].ToString()
                };
                return medicine;
            }
        }
        public void insert(Medicine medicine)
        {
            string query = "insert into medicine values(@name,@stock,@price,@brand)";
            using (SqlConnection conn = new SqlConnection(cs))
            {
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@name", medicine.name);
                sqlCommand.Parameters.AddWithValue("@stock", medicine.stock);
                sqlCommand.Parameters.AddWithValue("@price", medicine.price);
                sqlCommand.Parameters.AddWithValue("@brand", medicine.brand);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void update(Medicine medicine)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "update medicine set name=@name,stock=@stock,price=@price,brand=@brand where id=@id";
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                sqlCommand.Parameters.AddWithValue("@id", medicine.id);
                sqlCommand.Parameters.AddWithValue("@name", medicine.name);
                sqlCommand.Parameters.AddWithValue("@stock", medicine.stock);
                sqlCommand.Parameters.AddWithValue("@price", medicine.price);
                sqlCommand.Parameters.AddWithValue("@brand", medicine.brand);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public void delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(cs))
            {
                string query = "delete from medicine where id=" + id;
                SqlCommand sqlCommand = new SqlCommand(query, conn);
                conn.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
        public List<SelectListItem> getAllpharmaceuticalCompany()
        {
            List<SelectListItem> myList = new List<SelectListItem>();
            var data = new[]{
                 new SelectListItem{ Text="Square Pharmaceuticals",Value="1"},
                 new SelectListItem{ Text="Orion Pharma",Value="2"},
                 new SelectListItem{ Text="The ACME Laboratories Ltd",Value="3"},
                 new SelectListItem{ Text="Beximco Pharma",Value="4"},
                 new SelectListItem{ Text="Incepta Pharmaceuticals",Value="5"},
                 new SelectListItem{ Text="Renata Limited",Value="6"},
                 new SelectListItem{ Text="Opsonin Pharma Limited",Value="7"},
                 new SelectListItem{ Text="Orion Pharma",Value="8"},
                 new SelectListItem{ Text="Radiant Pharmaceuticals", Value = "9" }
             };
            myList = data.ToList();
            return myList;
        }
    }
}