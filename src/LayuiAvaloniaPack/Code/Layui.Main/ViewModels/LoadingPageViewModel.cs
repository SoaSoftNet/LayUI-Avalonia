﻿using Layui.Core.Mvvm;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Layui.Main.ViewModels
{
    public class LoadingPageViewModel : ViewModelBase
    {
        public LoadingPageViewModel(IContainerExtension container) : base(container)
        {
        }
    }
}
