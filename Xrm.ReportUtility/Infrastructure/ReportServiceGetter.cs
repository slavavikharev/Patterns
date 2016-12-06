﻿using System;
using Xrm.ReportUtility.Infrastructure.DataGetters;
using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Infrastructure
{
    internal static class ReportServiceGetter
    {
        public static IReportService Get(string filename) {
            var service = new ReportService(filename);

            if (filename.EndsWith(".txt"))
            {
                service.DataGetter = new TxtDataGetter();
                return service;
            }

            if (filename.EndsWith(".csv"))
            {
                service.DataGetter = new CsvDataGetter();
                return service;
            }

            if (filename.EndsWith(".xlsx"))
            {
                service.DataGetter = new XlsxDataGetter();
                return service;
            }

            throw new NotSupportedException("this extension not supported");
        }
    }
}
