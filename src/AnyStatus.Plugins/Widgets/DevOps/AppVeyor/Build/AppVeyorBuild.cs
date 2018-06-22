﻿using AnyStatus.API;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace AnyStatus
{
    [DisplayName("AppVeyor Build")]
    [Description("AppVeyor build status.")]
    [DisplayColumn("DevOps")]
    public class AppVeyorBuild : Build, ISchedulable, IWebPage, IStartable, IHealthCheck
    {
        [Required]
        [PropertyOrder(10)]
        [Category("AppVeyor")]
        [DisplayName("Account")]
        [Description("Required. AppVeyor account name.")]
        public string AccountName { get; set; }

        [Required]
        [PropertyOrder(20)]
        [Category("AppVeyor")]
        [DisplayName("Project Slug")]
        [Description("Required. Project slug is the last part of the AppVeyor project URL. For example: https://ci.appveyor.com/project/AccountName/Project-Slug")]
        public string ProjectSlug { get; set; }

        [PropertyOrder(30)]
        [Category("AppVeyor")]
        [DisplayName("API Token")]
        [Description("Optional. AppVeyor API token.")]
        public string ApiToken { get; set; }

        [Browsable(false)]
        public string URL => $"https://ci.appveyor.com/project/{Uri.EscapeDataString(AccountName)}/{ProjectSlug}";

        [PropertyOrder(40)]
        [Category("Source Control")]
        [DisplayName("Branch")]
        [Description("Optional. Branch to trigger.")]
        public string SourceControlBranch { get; set; }
    }
}