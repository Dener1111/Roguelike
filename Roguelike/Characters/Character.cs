using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Roguelike
{
    public class Character : INotifyPropertyChanged
    {
        char characterGraphic;
        public char CharacterGraphic
        {
            get => characterGraphic;
            set
            {
                characterGraphic = value;
                NotifyPropertyChanged();
            }
        }

        Vector2 position;
        public Vector2 Position
        {
            get => position;
            set
            {
                position = value;
                NotifyPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
