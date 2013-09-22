using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Routing;
using System.Web.Mvc;
using griptide.Domain.Entities;
using griptide.Domain.Abstract;
using griptide.Domain.Repository.Entries;

namespace griptide.Ninject
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            //return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
            
            if (controllerType == null)
            {
                throw new HttpException(404, "NotFound");
            }
            else
            {
                return (IController)ninjectKernel.Get(controllerType);
            }
        }

        private void AddBindings()
        {
            try
            {
                ninjectKernel.Bind<IEntryRepository>().To<EFEntryRepository>();
                ninjectKernel.Bind<IMenuItemRepository>().To<EFMenuItemRepository>();
                ninjectKernel.Bind<IPostRepository>().To<EFPostRepository>();
                ninjectKernel.Bind<ISubMenuItemRepository>().To<EFMenuSubItemRepository>();
                ninjectKernel.Bind<ILinksRepository>().To<EFLinksRepository>();
                ninjectKernel.Bind<ILinksGroupsRepository>().To<EFLinksGroupRepository>();
                ninjectKernel.Bind<IImagesRepository>().To<EFImageRepository>();
            }
            catch
            {
                throw new HttpException(404, "Unknown");
            }
        }
    }
}