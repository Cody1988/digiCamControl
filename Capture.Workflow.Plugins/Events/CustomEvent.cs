﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capture.Workflow.Core;
using Capture.Workflow.Core.Classes;
using Capture.Workflow.Core.Classes.Attributes;
using Capture.Workflow.Core.Interface;

namespace Capture.Workflow.Plugins.Events
{
    [Description("")]
    [PluginType(PluginType.Event)]
    [DisplayName("CustomEvent")]
    public class CustomEvent: IEventPlugin
    {
        public string Name { get; }
        private WorkFlowEvent _flowEvent;

        public WorkFlowEvent CreateEvent()
        {
            WorkFlowEvent workFlowEvent = new WorkFlowEvent();
            workFlowEvent.Properties.Items.Add(new CustomProperty()
            {
                Name = "Event",
                PropertyType = CustomPropertyType.String
            });
            return workFlowEvent;
        }

        public void RegisterEvent(WorkFlowEvent flowEvent)
        {
            _flowEvent = flowEvent;
            WorkflowManager.Instance.Message += Instance_Message;
        }


        private void Instance_Message(object sender, MessageEventArgs e)
        {
            if (e.Name == _flowEvent.Properties["Event"].Value)
            {
                var contex = e.Param as Context;
                if (contex != null)
                    WorkflowManager.Execute(_flowEvent.CommandCollection, contex);
            }
        }

        public void UnRegisterEvent(WorkFlowEvent flowEvent)
        {
            WorkflowManager.Instance.Message -= Instance_Message;
        }
    }
}
