﻿using Entities;
using System;
using System.Linq;
using System.Data.Entity;
using DataAccess.DataContext;
using System.Data.Entity.Infrastructure;
using DataAccess.Migrations;
using EntityFramework.BulkExtensions;

namespace Logger
{
    public class DbLogger : ILogger
    {

        private LogMessgeContext _context;

        public DbLogger()
        {
            _context = new LogMessgeContext();
        }

        public DbLogger(LogMessgeContext logMessageContext)
        {
            _context = logMessageContext;
        }

        public IQueryable<LogMessage> GetLogMessages()
        {
            return _context.LogMessages.Where(log => log.IsRead == false).OrderByDescending(log => log.Created);
        }

        public void UpdateLogMessage(int id, LogMessage message)
        {
            _context.Entry(message).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogMessageExists(id))
                {
                    throw new ArgumentException();
                }
                else
                {
                    throw;
                }
            }
        }

        public void WriteLogMessage(LogMessage message)
        {
            _context.LogMessages.Add(message);
            _context.SaveChanges();
        }

        public void ResetLogs()
        {
            _context.Database.ExecuteSqlCommand("delete from LogMessages");
            _context.BulkInsertOrUpdate(SeedData.GetSeedData(), InsertOptions.OutputIdentity);
            _context.SaveChanges();
        }

        private bool LogMessageExists(int id)
        {
            return _context.LogMessages.Count(e => e.ID == id) > 0;
        }
    }
}
