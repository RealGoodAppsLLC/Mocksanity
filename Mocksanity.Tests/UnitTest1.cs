using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using Xunit;

namespace RealGoodApps.Mocksanity.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(-5)]
        [InlineData(20)]
        [InlineData(0)]
        public void SetScore_ShouldUpdateTheUsersScore_GivenANewScore(int score)
        {
            var sut = new User();

            var isCalled = false;

            sut.OnScoreChanged += (scoreEvent) =>
            {
                Assert.Equal(score, scoreEvent.NewScore);
                Assert.Equal(0, scoreEvent.OldScore);
                isCalled = true;
            };

            sut.SetScore(score);

            Assert.Equal(score, sut.Score);
            Assert.True(isCalled);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(-1, 0)]
        [InlineData(5, 6)]
        public void IncrementScoreByOne_ShouldSetTheUsersScoreToSix_GivenAScoreOfFive(int existingScore, int expectedScore)
        {
            var sut = new User();

            sut.SetScore(existingScore);

            using var mock = MocksaneInitializer.Initialize(
                sut,
                u => u.SetScore(expectedScore));

            sut.IncrementScoreByOne();

            mock.VerifyOnce();
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(-1, -2)]
        [InlineData(5, 4)]
        public void DecrementScoreByOne_ShouldDecreaseTheScoreByOne_GivenAnExistingScore(int existingScore, int expectedScore)
        {
            var sut = new User();

            sut.SetScore(existingScore);

            using var mock = MocksaneInitializer.Initialize(
                sut,
                u => u.SetScore(expectedScore));

            sut.DecrementScoreByOne();

            mock.VerifyOnce();
        }
    }

    public class User
    {
        private int _score;

        public class ScoreChangedEvent : EventArgs
        {
            public int OldScore { get; set; }

            public int NewScore { get; set; }
        }

        public delegate void ScoreChanged(ScoreChangedEvent @event);

        public event ScoreChanged OnScoreChanged;

        public void IncrementScoreByOne()
        {
            SetScore(_score + 1);
        }

        public void DecrementScoreByOne()
        {
            SetScore(_score - 1);
        }

        public void SetScore(int newScore)
        {
            var oldScore = _score;
            _score = newScore;

            OnScoreChanged?.Invoke(new ScoreChangedEvent
            {
                OldScore = oldScore,
                NewScore = newScore,
            });
        }

        public int Score => _score;
    }
}
