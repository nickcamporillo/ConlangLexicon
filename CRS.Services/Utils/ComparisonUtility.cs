using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CRS.App_Level;
using CRS.Services;

namespace CRS.Services.Utils
{
    public enum FieldExistence
    {
        FieldOneNotFound = 1,
        FieldTwoNotFound = 2,
        BothFieldsNotFound = 3,
        BothFieldsExist = 4,
        BothFieldsExistButCannotBeCompared = 5
    }

    public enum ComparisonTestResult
    {
        TestInconclusive = 1,
        FieldOneAndFieldTwoAreEqual = 2,
        FieldOneIsGreaterThanFieldTwo = 3,
        FieldTwoIsGreaterThanFieldOne = 4,
        FieldOneAndTwoAreUnequal = 5
    }

    public class ComparisonUtility:IService
    {
        public int AccessCode
        {
            get;
            private set;
        }
        
        public ComparisonUtility(int accessCode)
        {
            this.AccessCode = accessCode;
        }

        private FieldExistence CanCompareFields(IEnumerationDetail fieldOneDetail, IEnumerationDetail fieldTwoDetail, object testPropertyOne, object testPropertyTwo)
        {
            FieldExistence testFieldExistentce = FieldExistence.BothFieldsExist;

            //GetFieldName and their properties to be tested
            System.Reflection.PropertyInfo p1 = null;
            System.Reflection.PropertyInfo p2 = null;

            p1 = testPropertyOne.GetType().GetProperties().Where(c => c.Name == fieldOneDetail.EnumerationName).FirstOrDefault();
            p2 = testPropertyTwo.GetType().GetProperties().Where(c => c.Name == fieldTwoDetail.EnumerationName).FirstOrDefault();

            if (p1 == null && p2 == null)
            {
                testFieldExistentce = FieldExistence.BothFieldsNotFound;
            }
            else if (p1 == null && p2 != null)
            {
                testFieldExistentce = FieldExistence.FieldOneNotFound;
            }
            else if (p1 != null && p2 == null)
            {
                testFieldExistentce = FieldExistence.FieldTwoNotFound;
            }
            
            if (p1.PropertyType != p2.PropertyType)
                testFieldExistentce = FieldExistence.BothFieldsExistButCannotBeCompared;     

            return testFieldExistentce;
        }

        private T GetComparisonValue<T>(IEnumerationDetail fieldInfo, object comparisonTarget)
        {
            T retVal = default(T);
            var propertyValue = comparisonTarget.GetType().GetProperty(fieldInfo.EnumerationName).GetValue(comparisonTarget, null);
            Type t = propertyValue.GetType();

            if (propertyValue.GetType() == typeof(T))
            {
                retVal = (T)propertyValue;
            }

            return retVal;
        }

        public ComparisonTestResult Compare_FieldOne_GreaterThan_FieldTwo(IEnumerationDetail eTypefieldOne, IEnumerationDetail eTypeFieldTwo, int comparisonOne, int comparisonTwo)
        {
            ComparisonTestResult retVal = ComparisonTestResult.TestInconclusive;
            Func<bool> testResult_FieldOne_GreaterThan_FieldTwo = () => comparisonOne > comparisonTwo;
            bool testResult = false;

            testResult = testResult_FieldOne_GreaterThan_FieldTwo.Invoke();
            retVal = (testResult ? ComparisonTestResult.FieldOneIsGreaterThanFieldTwo : ComparisonTestResult.FieldTwoIsGreaterThanFieldOne);

            return retVal;
        }

        public ComparisonTestResult Compare_FieldOne_GreaterThan_FieldTwo(IEnumerationDetail eTypefieldOne, IEnumerationDetail eTypeFieldTwo, double comparisonOne, double comparisonTwo)
        {
            ComparisonTestResult retVal = ComparisonTestResult.TestInconclusive;
            Func<bool> testResult_FieldOne_GreaterThan_FieldTwo = () => comparisonOne > comparisonTwo;
            bool testResult = false;

            testResult = testResult_FieldOne_GreaterThan_FieldTwo.Invoke();
            retVal = (testResult ? ComparisonTestResult.FieldOneIsGreaterThanFieldTwo : ComparisonTestResult.FieldTwoIsGreaterThanFieldOne);

            return retVal;
        }

        public ComparisonTestResult Compare_FieldOne_GreaterThan_FieldTwo(IEnumerationDetail eTypefieldOne, IEnumerationDetail eTypeFieldTwo, string comparisonOne, string comparisonTwo)
        {
            ComparisonTestResult retVal = ComparisonTestResult.TestInconclusive;

            int ts1 = string.Compare(comparisonOne, comparisonTwo);
            int ts2 = string.Compare(comparisonTwo, comparisonOne);

            Func<bool> testResult_FieldOne_GreaterThan_FieldTwo = () => ts1 > ts2;
            bool testResult = false;

            testResult = testResult_FieldOne_GreaterThan_FieldTwo.Invoke();
            retVal = (testResult ? ComparisonTestResult.FieldOneIsGreaterThanFieldTwo : ComparisonTestResult.FieldTwoIsGreaterThanFieldOne);

            return retVal;
        }

        public ComparisonTestResult Compare_FieldOne_GreaterThan_FieldTwo<TEntityOne,TEntityTwo,T>(IEnumerationDetail eTypefieldOne, IEnumerationDetail eTypeFieldTwo, TEntityOne comparisonOne, TEntityTwo comparisonTwo) where TEntityOne : class where TEntityTwo:class
        {
            ComparisonTestResult retVal = ComparisonTestResult.TestInconclusive;

            bool isInt = false;
            bool isDouble = false;
            bool isString = false;

            //Make sure the EnumerationDetails come from the same Enumeration class:
            if (eTypefieldOne.EnumerationId != eTypeFieldTwo.EnumerationId)
            {
                return retVal;
            }

            if (CanCompareFields(eTypefieldOne, eTypeFieldTwo, comparisonOne, comparisonTwo) != FieldExistence.BothFieldsExist)
            {
                return retVal;
            }

            isInt = (GetComparisonValue<int>(eTypefieldOne, comparisonOne) != null);
            if (isInt)
            {
                int cInt1 = GetComparisonValue<int>(eTypefieldOne, comparisonOne);
                int cInt2 = GetComparisonValue<int>(eTypeFieldTwo, comparisonTwo);

                retVal = Compare_FieldOne_GreaterThan_FieldTwo(eTypefieldOne, eTypeFieldTwo, cInt1, cInt2);

                return retVal;
            }

            isDouble = (GetComparisonValue<double>(eTypefieldOne, comparisonOne) != null);
            if (isDouble)
            {
                double cDouble1 = GetComparisonValue<double>(eTypefieldOne, comparisonOne);
                double cDouble2 = GetComparisonValue<double>(eTypeFieldTwo, comparisonTwo);

                retVal = Compare_FieldOne_GreaterThan_FieldTwo(eTypefieldOne, eTypeFieldTwo, cDouble1, cDouble2);

                return retVal;
            }

            isString = (GetComparisonValue<string>(eTypefieldOne, comparisonOne) != null);
            if (isString)
            {
                string cString1 = GetComparisonValue<string>(eTypefieldOne, comparisonOne);
                string cString2 = GetComparisonValue<string>(eTypeFieldTwo, comparisonTwo);

                retVal = Compare_FieldOne_GreaterThan_FieldTwo(eTypefieldOne, eTypeFieldTwo, cString1, cString2);
                
                return retVal;
            }

            return retVal;
        }

        public ComparisonTestResult Compare_FieldOne_Equals_FieldTwo<TEntityOne, TEntityTwo, T>(IEnumerationDetail eTypefieldOne, IEnumerationDetail eTypeFieldTwo, TEntityOne comparisonOne, TEntityTwo comparisonTwo)
            where TEntityOne : class
            where TEntityTwo : class
        {
            ComparisonTestResult retVal = ComparisonTestResult.TestInconclusive;

            bool isInt = false;
            bool isDouble = false;
            bool isString = false;

            //Make sure the EnumerationDetails come from the same Enumeration class:
            if (eTypefieldOne.EnumerationId != eTypeFieldTwo.EnumerationId)
            {
                return retVal;
            }

            if (CanCompareFields(eTypefieldOne, eTypeFieldTwo, comparisonOne, comparisonTwo) != FieldExistence.BothFieldsExist)
            {
                return retVal;
            }

            isInt = (GetComparisonValue<int>(eTypefieldOne, comparisonOne) != null);
            if (isInt)
            {
                int cInt1 = GetComparisonValue<int>(eTypefieldOne, comparisonOne);
                int cInt2 = GetComparisonValue<int>(eTypeFieldTwo, comparisonTwo);

                retVal = ((cInt1 == cInt2) ? ComparisonTestResult.FieldOneAndFieldTwoAreEqual : ComparisonTestResult.FieldOneAndTwoAreUnequal);

                return retVal;
            }

            isDouble = (GetComparisonValue<double>(eTypefieldOne, comparisonOne) != null);
            if (isDouble)
            {
                double cDouble1 = GetComparisonValue<double>(eTypefieldOne, comparisonOne);
                double cDouble2 = GetComparisonValue<double>(eTypeFieldTwo, comparisonTwo);

                retVal = ((cDouble1 == cDouble2) ? ComparisonTestResult.FieldOneAndFieldTwoAreEqual : ComparisonTestResult.FieldOneAndTwoAreUnequal);

                return retVal;
            }

            isString = (GetComparisonValue<string>(eTypefieldOne, comparisonOne) != null);
            if (isString)
            {
                string cString1 = GetComparisonValue<string>(eTypefieldOne, comparisonOne);
                string cString2 = GetComparisonValue<string>(eTypeFieldTwo, comparisonTwo);

                int ts1 = string.Compare(cString1, cString2);
                int ts2 = string.Compare(cString2, cString1);

                retVal = ((ts1 == ts2) ? ComparisonTestResult.FieldOneAndFieldTwoAreEqual : ComparisonTestResult.FieldOneAndTwoAreUnequal);

                return retVal;
            }

            return retVal;
        }

    }
}
