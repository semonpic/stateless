﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Stateless.Tests
{
    [TestFixture]
    public class TransitioningTriggerBehaviourFixture
    {
        [Test]
        public void TransitionsToDestinationState()
        {
            var transtioning = new StateMachine<State, Trigger>.TransitioningTriggerBehaviour(Trigger.X, State.C, () => true);
            State destination;
            Assert.IsTrue(transtioning.ResultsInTransitionFrom(State.B, out destination));
            Assert.AreEqual(State.C, destination);
        }

        [Test]
        public void ExposesCorrectUnderlyingTrigger()
        {
            var transtioning = new StateMachine<State, Trigger>.TransitioningTriggerBehaviour(
                Trigger.X, State.C, () => true);

            Assert.AreEqual(Trigger.X, transtioning.Trigger);
        }

        [Test]
        public void WhenGuardConditionFalse_IsGuardConditionMetIsFalse()
        {
            var transtioning = new StateMachine<State, Trigger>.TransitioningTriggerBehaviour(
                Trigger.X, State.C, () => false);

            Assert.IsFalse(transtioning.IsGuardConditionMet);
        }

        [Test]
        public void WhenGuardConditionTrue_IsGuardConditionMetIsTrue()
        {
            var transtioning = new StateMachine<State, Trigger>.TransitioningTriggerBehaviour(
                Trigger.X, State.C, () => true);

            Assert.IsTrue(transtioning.IsGuardConditionMet);
        }
    }
}
