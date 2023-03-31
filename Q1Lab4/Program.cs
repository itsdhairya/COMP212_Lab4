using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Q1Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            // Connect to the database
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\dhair\Downloads\sem2\Programming 3 - COMP 212 - 006\Lab04 - Solution Template\Q2Lab4\Database\books.mdf;Integrated Security=True";
            using SqlConnection connection = new SqlConnection(connectionString);
            // code here
            connection.Open();

            // Invoke the methods to answer the questions
            Question1_1(connection);
            Question1_2(connection);
            Question1_3(connection);
            Question1_4(connection);
            Question1_5(connection);
            Question1_6(connection);
        }

        // 1.1 List the names of the countries in alphabetical order [0.5 mark]
        static void Question1_1(SqlConnection connection)
        {
            Console.WriteLine("1.1 List the names of the countries in alphabetical order");
            string query = "SELECT Name FROM Country ORDER BY Name";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        // 1.2 List the names of the countries in descending order of number of resources [0.5 mark]
        static void Question1_2(SqlConnection connection)
        {
            Console.WriteLine("1.2 List the names of the countries in descending order of number of resources");
            string query = "SELECT Name FROM Country ORDER BY Resources DESC";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        // 1.3 List the names of the countries that shares a border with Argentina [0.5 mark]
        static void Question1_3(SqlConnection connection)
        {
            Console.WriteLine("1.3 List the names of the countries that shares a border with Argentina");
            string query = "SELECT Name FROM Country WHERE Id IN (SELECT BorderingCountry FROM Border WHERE Country = 'Argentina')";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        // 1.4 List the names of the countries that has more than 10,000,000 population [0.5 mark]
        static void Question1_4(SqlConnection connection)
        {
            Console.WriteLine("1.4 List the names of the countries that has more than 10,000,000 population");
            string query = "SELECT Name FROM Country WHERE Population > 10000000";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                Console.WriteLine(name);
            }
            Console.WriteLine();
        }

        // 1.5 List the country with highest population [1 mark]
        static void Question1_5(SqlConnection connection)
        {
            Console.WriteLine("1.5 List the country with highest population");
            string query = "SELECT TOP 1 Name FROM Country ORDER BY Population DESC";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string name = reader.GetString(0);
                Console.WriteLine(name);
            }
        }

        // 1.6 List the population of each continent (in millions) [2 marks]
        static void Question1_6(SqlConnection connection)
        {
            Console.WriteLine("1.6 List the population of each continent (in millions)");
            string query = "SELECT Continent, SUM(Population) AS Population FROM Country GROUP BY Continent";
            using SqlCommand command = new SqlCommand(query, connection);
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string continent = reader.GetString(0);
                int population = reader.GetInt32(1);
                double populationInMillions = (double)population / 1000000;
                Console.WriteLine($"{continent}: {populationInMillions:N2} million");
            }
        }
    }
}
