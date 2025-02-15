﻿using Avalonia;
using Avalonia.Controls;
using Layui.Core.Mvvm;
using Layui.Core.Resources;
using Layui.Main.Models;
using Layui.Main.Views;
using Layui.Tools.Languages;
using LayUI.Avalonia.Enums;
using LayUI.Avalonia.Interface;
using LayUI.Avalonia.Interface.Page;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace Layui.Main.ViewModels
{
    public class HomePageViewModel : ViewModelBase, ILayPageInitialized
    {
        private ILayMessage message;
        private ResourceDictionary _Language;
        public ResourceDictionary Language
        {
            get { return _Language; }
            set { SetProperty(ref _Language, value); }
        }
        private bool _IsEn;
        /// <summary>
        /// 是否为英文
        /// </summary>
        public bool IsEn
        {
            get { return _IsEn; }
            set { SetProperty(ref _IsEn, value); OnLanugageChanged(value); }
        }
        /// <summary>
        /// 语言切换
        /// </summary>
        /// <param name="value"></param>
        private void OnLanugageChanged(bool value)
        {
            if(value) LanguageManager.Instance.LoadLanguage("Languages/ch-en.axaml");
            else LanguageManager.Instance.LoadLanguage("Languages/zh-cn.axaml"); 
        }

        public HomePageViewModel(IContainerExtension container) : base(container) 
        {
            message = container.Resolve<ILayMessage>();
        }
        private MenuInfo _MenuInfo;
        public MenuInfo MenuInfo
        {
            get { return _MenuInfo; }
            set { SetProperty(ref _MenuInfo, value); }
        }
        private ObservableCollection<MenuInfo> _Menus;
        /// <summary>
        /// 菜单集合
        /// </summary>
        public ObservableCollection<MenuInfo> Menus
        {
            get { return _Menus; }
            set { SetProperty(ref _Menus, value); }
        }
        private DelegateCommand<MenuInfo> _GoPageCommand;
        public DelegateCommand<MenuInfo> GoPageCommand =>
            _GoPageCommand ?? (_GoPageCommand = new DelegateCommand<MenuInfo>(ExecuteGoPageCommand));

        void ExecuteGoPageCommand(MenuInfo info)
        {
            Region.RequestNavigate(SystemResource.Nav_HomeContent, info.PageKey);
        }
        private ObservableCollection<MenuInfo> CreateMenus()
        {
            ObservableCollection<MenuInfo> menus = new ObservableCollection<MenuInfo>
            {
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.ButtonPage, Title ="Button"},
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.FormPage, Title = "Form" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.ImagePage, Title ="Image" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.ProgressBarPage, Title ="ProgressBar" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.KeyboardPage, Title = "Keyboard" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.DialogPage, Title = "Dialog" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.CardPage, Title = "Card" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.MessagePage, Title = "Message" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.NotificationPage, Title = "Notification" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.LoadingPage, Title = "Loading" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.TabControlPage, Title = "TabControl" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.StepBarPage, Title = "StepBar" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.CarouselPage, Title = "Carousel" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.ExpanderPage, Title = "Expander" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.GroupBoxPage, Title = "GroupBox" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.TreeViewPage, Title = "TreeView" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.LegendPage, Title = "Legend" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.BadgePage, Title = "Badge" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.DrawerPage, Title = "Drawer" },
                //new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.GridPage, Title = "Grids" },
                new MenuInfo() { FontIcon = "\xfab9", PageKey = SystemResource.MenuPage, Title = "Menu" },
            };
            return menus;
        }
        public async override void ExecuteLoadedCommand()
        {
            OnLanugageChanged(false);
            Menus = CreateMenus();
            MenuInfo= Menus?.FirstOrDefault();
            if(MenuInfo!=null) Region.RegisterViewWithRegion(SystemResource.Nav_HomeContent, MenuInfo.PageKey);
            await Task.Delay(1000);
            message.Show($"欢迎使用LayUI-Avalonia", "RootMessage",TimeSpan.FromMilliseconds(3000));
        }

        public void Loaded()
        {
            LoadedCommand.Execute();
        }

        public void Unloaded()
        {

        }
    }
}
