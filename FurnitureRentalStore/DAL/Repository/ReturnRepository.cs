﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureRentalStore.DAL.Interfaces;
using FurnitureRentalStore.Model;
using MySql.Data.MySqlClient;

namespace FurnitureRentalStore.DAL.Repository
{
    internal class ReturnRepository : IRepository<Return>
    {
        private readonly string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReturnTransactionRepository"/> class.
        /// </summary>
        public ReturnRepository()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["MySqlDbConnection"].ToString();
        }

        public void Add(Return entity)
        {
            const string query = "INSERT INTO `RETURN`(returnTransactionID, rentalTransactionID, itemID, fineTotal, quantityReturned) VALUES(@returnTransactionID, @rentalTransactionID, @itemID, @fineTotal, @quantityReturned)";

            try
            {
                using (var conn = new MySqlConnection(this.connectionString))
                {
                    conn.Open();

                    using (var cmd = new MySqlCommand(query, conn))
                    {
                        ParameterizeQuery(entity, cmd);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Parameterizes the query.
        /// </summary>
        /// <param name="aRental">a member.</param>
        /// <param name="cmd">The command.</param>
        private static void ParameterizeQuery(Return aRental, MySqlCommand cmd)
        {
            cmd.Parameters.Add("@returnTransactionID", MySqlDbType.Int32);
            cmd.Parameters.Add("@rentalTransactionID", MySqlDbType.Int32);
            cmd.Parameters.Add("@itemID", MySqlDbType.Int32);
            cmd.Parameters.Add("@fineTotal", MySqlDbType.Double);
            cmd.Parameters.Add("@quantityReturned", MySqlDbType.Int32);

            cmd.Parameters["@returnTransactionID"].Value = aRental.ReturnTransactionId;
            cmd.Parameters["@rentalTransactionID"].Value = aRental.RentalTransactionId;
            cmd.Parameters["@itemID"].Value = aRental.ItemId;
            cmd.Parameters["@fineTotal"].Value = aRental.FineTotal;
            cmd.Parameters["@quantityReturned"].Value = aRental.QuantityReturned;

            cmd.ExecuteNonQuery();
        }

        public Return GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Return> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
