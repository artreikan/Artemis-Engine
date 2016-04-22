﻿#region Using Statement

using Microsoft.Xna.Framework;

using System;

#endregion

namespace Artemis.Engine.Effectors.Special
{
    /// <summary>
    /// An effector that acts on the y-component of a Vector2 object.
    /// </summary>
    public class YCoordEffector : CoerciveEffector<Vector2, float>
    {
        #region Constructors

        public YCoordEffector( string fieldName
                             , string effectorName
                             , EffectorFunction<float> func
                             , EffectorOperatorType opType = EffectorOperatorType.InPlace
                             , EffectorValueType valueType = EffectorValueType.RelativeToStart
                             , bool reusable = false )
            : base(fieldName, effectorName, func, opType, valueType, reusable) { }

        public YCoordEffector( string fieldName
                             , string effectorName
                             , EffectorFunction<float> func
                             , Func<float, float, float> op
                             , EffectorValueType valueType = EffectorValueType.RelativeToStart
                             , bool reusable = false )
            : base(fieldName, effectorName, func, op, valueType, reusable) { }

        public YCoordEffector( string fieldName
                             , string effectorName
                             , EffectorFunction<float> func
                             , EffectorOperator<float> op
                             , EffectorValueType valueType = EffectorValueType.RelativeToStart
                             , bool reusable = false )
            : base(fieldName, effectorName, func, op, valueType, reusable) { }

        #endregion

        protected override float CoerceTo(Vector2 val)
        {
            return val.Y;
        }

        protected override void AssignNextValue(float nextVal)
        {
            var prevVec = Get<Vector2>(EffectedPropertyName);
            prevVec.Y = nextVal;
            Set(EffectedPropertyName, prevVec);
        }

        protected override float Combine_InPlaceAndRelativeToStart(float init, float combined)
        {
            return init + combined;
        }
    }
}
