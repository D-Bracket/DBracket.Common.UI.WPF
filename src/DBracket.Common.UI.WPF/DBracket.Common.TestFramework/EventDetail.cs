﻿using System.Collections.ObjectModel;

namespace DBracket.Common.TestFramework
{
    public class EventDetail
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public EventDetail(string name)
        {
            Name = name;
        }
        #endregion



        #region "--------------------------------- Methods ---------------------------------"
        #region "----------------------------- Public Methods ------------------------------"

        #endregion

        #region "----------------------------- Private Methods -----------------------------"

        #endregion

        #region "------------------------------ Event Handling -----------------------------"

        #endregion
        #endregion



        #region "--------------------------- Public Propterties ----------------------------"
        #region "------------------------------- Properties --------------------------------"
        public string Name { get => _name; set { _name = value; } }
        private string _name;

        public ObservableCollection<EventDetailParameter> Parameters { get => _parameters; set { _parameters = value; } }
        private ObservableCollection<EventDetailParameter> _parameters = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}