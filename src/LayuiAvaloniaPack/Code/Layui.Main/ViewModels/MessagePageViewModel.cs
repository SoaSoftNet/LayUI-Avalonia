﻿using Layui.Core.Mvvm;
using LayUI.Avalonia.Enums;
using LayUI.Avalonia.Interface;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Layui.Main.ViewModels
{
    public class MessagePageViewModel : ViewModelBase
    {
        int num = 0;
        private ILayMessage message;
        public MessagePageViewModel(IContainerExtension container) : base(container)
        {
            message = container.Resolve<ILayMessage>();
        }
        private DelegateCommand _MessageCommand;
        public DelegateCommand MessageCommand =>
            _MessageCommand ?? (_MessageCommand = new DelegateCommand(ExecuteMessageCommand));
        bool flag = false;
        void ExecuteMessageCommand()
        {

            num++;
            if (flag)
            {
                flag= false;
                message.Show($"尼玛，第{num}次打酱油", "RootMessage", MessageType.Shake);
            }
            else
            {
                flag = true;
                message.Show($"尼玛，第{num}次打酱油", "RootMessage", MessageType.Zoom);
            }
        }
    }
}
