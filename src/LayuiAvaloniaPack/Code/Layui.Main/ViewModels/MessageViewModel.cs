﻿using Avalonia.Logging;
using Avalonia;
using LayUI.Avalonia;
using LayUI.Avalonia.Interface;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Prism.Ioc;

namespace Layui.Main.ViewModels
{
    public class MessageViewModel : BindableBase,ILayDialogAware
    {
        private ILayDialogService layDialog;
        //方式一，采用Prism 默认VM构造注入
        public MessageViewModel(ILayDialogService dialogService)
        {
            layDialog = dialogService;
        }
        //方式二，采用Avalonia ICO获取Prism中IContainerExtension接口进行抓取Prism IOC中的ILayDialogService服务接口
        //public MessageViewModel()
        //{
        //    var Container = AvaloniaLocator.Current.GetService<IContainerExtension>();
        //    layDialog = Container.Resolve<ILayDialogService>();
        //}
        private DelegateCommand _CloseCommand;

        public event Action<ILayDialogResult> RequestClose;

        public DelegateCommand CloseCommand =>
            _CloseCommand ?? (_CloseCommand = new DelegateCommand(ExecuteCloseCommand));

        void ExecuteCloseCommand()
        {
            RequestClose?.Invoke(null);
        }
        private DelegateCommand _GoCommand;
        public DelegateCommand GoCommand =>
            _GoCommand ?? (_GoCommand = new DelegateCommand(ExecuteGoCommand));

        void ExecuteGoCommand()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://space.bilibili.com/48808444?spm_id_from=..0.0",
                UseShellExecute = true
            });
            RequestClose?.Invoke(null);
        }
        public void OnDialogOpened(ILayDialogParameter parameters)
        {
           
        }
    }
}
