﻿using DBracket.Common.UI.WPF.Bases;
using System.Collections.ObjectModel;

namespace DBracket.Common.UI.TestFramework.Protocol
{
    public class TestResult : PropertyChangedBase
    {
        #region "----------------------------- Private Fields ------------------------------"

        #endregion



        #region "------------------------------ Constructor --------------------------------"
        public TestResult(Test test)
        {
            Test = test;
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
        public bool IsExpanded { get => _isExpanded; set { _isExpanded = value; OnMySelfChanged(); } }
        private bool _isExpanded;



        public ResultStates Result { get => _result; set { _result = value; OnMySelfChanged(); } }
        private ResultStates _result = ResultStates.NOTEST;

        public Test Test { get => _test; set { _test = value; OnMySelfChanged(); } }
        private Test _test;

        public ObservableCollection<EventResult> Events { get => _events; set { _events = value; OnMySelfChanged(); } }
        private ObservableCollection<EventResult> _events = new();
        #endregion

        #region "--------------------------------- Events ----------------------------------"

        #endregion
        #endregion
    }
}