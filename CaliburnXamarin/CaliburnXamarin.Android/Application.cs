using System;
using System.Collections.Generic;
using System.Reflection;
using Android.App;
using Android.Runtime;
using Caliburn.Micro;
using CaliburnXamarin.ViewModels;
using Unity;

namespace CaliburnXamarin.Droid
{
    [Application]
    public class Application : CaliburnApplication
    {
        private IUnityContainer _unityContainer;

        public Application(IntPtr javaReference, JniHandleOwnership transfer)
            : base(javaReference, transfer)
        {

        }

        public override void OnCreate( )
        {
            base.OnCreate( );

            Initialize( );
        }

        protected override void Configure( )
        {
            _unityContainer = new UnityContainer( );
            _unityContainer.RegisterInstance(_unityContainer);
            _unityContainer.RegisterType<App>(TypeLifetime.Singleton);
            _unityContainer.RegisterType<IEventAggregator, EventAggregator>(TypeLifetime.Singleton);
        }

        protected override IEnumerable<Assembly> SelectAssemblies( )
        {
            return new[ ]
            {
                GetType().Assembly,
                typeof (App).Assembly
            };
        }

        protected override void BuildUp(object instance)
        {
            _unityContainer.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _unityContainer.ResolveAll(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            _unityContainer.AddExtension(new Diagnostic()); 
            var app= _unityContainer.Resolve(service, key);


            return app; 
        }
    }
}