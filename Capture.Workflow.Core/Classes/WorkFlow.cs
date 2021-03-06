﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CameraControl.Devices.Classes;

namespace Capture.Workflow.Core.Classes
{
    public class WorkFlow
    {
        public ObservableCollection<WorkFlowView> Views { get; set; }
        public ObservableCollection<WorkFlowEvent> Events { get; set; }
        public VariableCollection Variables { get; set; }
        public CustomPropertyCollection Properties { get; set; }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Version { get; set; }

        public WorkFlow()
        {
            Views = new ObservableCollection<WorkFlowView>();
            Variables = new VariableCollection();
            Events = new AsyncObservableCollection<WorkFlowEvent>();
            Id = Guid.NewGuid().ToString();
            Name = "New Workflow";
            Properties = new CustomPropertyCollection();
            Description = "";
            Version = "0.0.1";

            Properties.Add(new CustomProperty()
            {
                Name = "Author",
                PropertyType = CustomPropertyType.String
            });
            Properties.Add(new CustomProperty()
            {
                Name = "Forum",
                PropertyType = CustomPropertyType.String
            });
            Properties.Add(new CustomProperty()
            {
                Name = "License url",
                PropertyType = CustomPropertyType.String
            });
            Properties.Add(new CustomProperty()
            {
                Name = "BaseColorScheme",
                PropertyType = CustomPropertyType.ValueList,
                ValueList = {"Light","Dark"},
                Value = "Light",
            });
            Properties.Add(new CustomProperty()
            {
                Name = "ColorScheme",
                PropertyType = CustomPropertyType.ValueList,
                ValueList = { "yellow", "amber", "deeporange", "lightblue", "teal", "cyan", "pink", "green", "deeppurple", "indigo", "lightgreen", "blue", "lime", "red", "orange", "purple", "bluegrey", "grey", "brown" },
                Value = "blue",
            });
            Properties.Add(new CustomProperty()
            {
                Name = "HideTileBar",
                PropertyType = CustomPropertyType.Bool
            });
            Properties.Add(new CustomProperty()
            {
                Name = "FullScreen",
                PropertyType = CustomPropertyType.Bool
            });
        }


        public WorkFlowView GetView(string name)
        {
            foreach (var view in Views)
            {
                if (view.Name == name)
                    return view;
            }
            return null;
        }

    }
}
