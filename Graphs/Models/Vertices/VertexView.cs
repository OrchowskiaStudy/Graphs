﻿using Graphs.Models.BL;
using Graphs.ViewModels;
using System;

namespace Graphs.Models.Vertices
{
    public class Vertex : ViewModelBase, IComparable<Vertex>
    {
        public int Number { get; private set; }
        public string Id { get; set; }
        public Guid Uid { get; private set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }

        public Vertex(string id, string name = "")
        {
            Number = GraphContext.VertexCount;
            Id = id;
            Name = name;
            Uid = Guid.NewGuid();
        }

        public override bool Equals(object obj)
        {
            if (obj is Vertex edge)
            {
                return edge.Id == Id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17 * 23 + Id.GetHashCode();
                return hash;
            }
        }

        public int CompareTo(Vertex other)
        {
            return Number.CompareTo(other.Number);
        }
    }
}