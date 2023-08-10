﻿using MPAD_TestTimer;
using System.Collections.Generic;
//using TestLib;
//using static EqLib.EqSwitchMatrix;

namespace TestPlanCommon.CommonModel
{
    public class TesterManager
    {
        public ITesterSite CurrentTester;

        public TesterManager(ITesterSite testerLocation)
        {
            CurrentTester = testerLocation;
        }
    }

    /// <summary>
    /// Provide flexibility for variation between testers and sites.
    /// </summary>
    public interface ITesterSite
    {
        string GetVisaAlias(string visaAlias, byte site);

        string GetHandlerName();

        //Rev GetSwitchMatrixRevision();

        List<KeyValuePair<string, string>> GetSmuSetting();
    }

    /// <summary>
    /// Here for now, may not be needed.
    /// </summary>
    public interface IEquipmentInitializer
    {
        void SetTester(ITesterSite tester);

        //void InitializeSwitchMatrix(bool isMagicBox);

        bool InitializeHSDIO();

        //bool LoadVector(MipiTestConditions tc);

        void InitializeSmu();

        ValidationDataObject InitializeDC(ClothoLibAlgo.Dictionary.Ordered<string, string[]> DcResourceTempList);

        void InitializeChassis();

        void InitializeRF(string targetVST);

        void InitializeHandler(string handlerType, string visaAlias);
    }
}