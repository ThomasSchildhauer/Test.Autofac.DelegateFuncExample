﻿using Autofac;
using Autofac.Features.OwnedInstances;
using AutofacDelegateFuncExample.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacDelegateFuncExample
{
    public class ApplicationStart : IApplicationStart
    {
        IDependency _beans;

        public void Run()
        {
            OrdinaryWork();
            Console.ReadKey();
        }

        // ToDo finish and test this Construktor
        //public ApplicationStart(Func<string, IDependency> func)
        //{               
        //    
        //}

        /// <summary>
        /// 
        /// </summary>
        public void OrdinaryWork()
        {
            // ToDo Try to get this from Construktor with dependency injection
            Func<String, IDependency> factory = Autofac.ContainerConfig.container.Resolve<Func<String, IDependency>>();

            IDependency biscuits = factory("biscuits");
            Console.Error.WriteLine(biscuits.Message());

            IDependency beans = factory("beans");
            Console.Error.WriteLine(beans.Message());
        }

        /// <summary>
        /// 
        /// </summary>
        public void DisposableWork()
        {
            // ToDo Try to get this from Construktor with dependency injection
            Func<String, Owned<IDisposableDependency>> factory = Autofac.ContainerConfig.container.ResolveNamed<Func<String, Owned<IDisposableDependency>>>("disposable-factory");

            using (Owned<IDisposableDependency> item = factory("owned"))
            {
                Console.Error.WriteLine(item.Value.Message());
            }
        }
    }
}
