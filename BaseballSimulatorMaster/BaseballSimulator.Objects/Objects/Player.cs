using System;
using System.Collections.Generic;
using System.Text;
using BaseballSimulator.Objects.Utilities;

namespace BaseballSimulator.Objects.Objects
{
    public class Player
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; }
        public PlayerPosition Position { get; private set; }
        public string PositionString { get; private set; }

        public Player(string firstName, string lastName, DateTime dateOfBirth, PlayerPosition position)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Position = position;
            PositionString = PlayerPositionHelper.GetPlayerPositionString(position);
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} " +
                   $"\nPosition: {PositionString} " +
                   $"\nDate of Birth: {DateOfBirth.ToShortDateString()}";
        }

        public void ChangePlayerPosition(PlayerPosition newPosition)
        {
            Position = newPosition;
            PositionString = PlayerPositionHelper.GetPlayerPositionString(newPosition);
        }
    }
}
