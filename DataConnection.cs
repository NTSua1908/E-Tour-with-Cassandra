﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cassandra;

namespace Tour
{
    class DataConnection
    {
        public static DataConnection Ins { 
            get {
                if (_Ins == null)
                    _Ins = new DataConnection();
                return _Ins;
            } 
            set
            {
                _Ins = value;
            }
        }
        private static DataConnection _Ins;

        public ISession session;
        private string IP = "172.30.67.65";
        private string Datacenter = "datacenter1";

        private DataConnection()
        {
            session = getConnect();
            session.Execute("use TourManagement;");
        }
        public ISession getConnect()
        {
            return session = Cluster.Builder()
                                 .AddContactPoints(IP)
                                 .WithPort(9042)
                                 .WithLoadBalancingPolicy(new DCAwareRoundRobinPolicy(Datacenter))
                                 //.WithAuthProvider(new PlainTextAuthProvider(< Username >, < Password >))
                                 .Build()
                                 .Connect();
        }
            
    }
}
