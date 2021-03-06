﻿using System;
using System.Collections.Generic;
using TCC_LOSPACO.Models;

namespace TCC_LOSPACO.DAO {
    public class ScheduleDAO {
        private static Database db = new Database();
        public static List<Schedule> GetList() {
            var list = new List<Schedule>();
            db.ReaderRows(db.ReturnCommand("select * from vw_SchedulesCustomer"), row => {
                list.Add(new Schedule(Convert.ToUInt32(row[0]), EmployeeDAO.GetById(Convert.ToUInt32(row[1])), CustomerDAO.GetById(Convert.ToUInt32(row[2])), ServiceDAO.GetById(Convert.ToUInt16(row[3])), row[4] + ""));
            });
            return list;
        }

        public static Schedule GetById(uint id) {
            object[] row = db.ReaderRow(db.ReturnCommand($"select * from vw_SchedulesCustomer where SchedId = '{id}'"));
            Schedule schedule = new Schedule(Convert.ToUInt32(row[0]), EmployeeDAO.GetById(Convert.ToUInt32(row[1])), CustomerDAO.GetById(Convert.ToUInt32(row[2])), ServiceDAO.GetById(Convert.ToUInt16(row[3])), row[4] + "");
            return schedule;
        }
    }
}