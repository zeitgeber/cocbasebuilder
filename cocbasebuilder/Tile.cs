﻿using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Linq;
using cocbasebuilder.Model;

namespace cocbasebuilder
{

    class Tile
    {
        //private const int maxRandomTries = 200;
        private int size;
        private Matrix<double> tile;
        public Matrix<double> heatmap;
        public Matrix<double> scoremap;
        //private Building[] buildings;
        public Dictionary<int, double> buildingScores;
        private Random random = new Random((int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber)));

        public Tile(int size)
        {
            this.size = size;
            //buildings = new Building[size * size];
            this.tile = Matrix<double>.Build.Dense(size, size, GlobalVar.BaseShape);
            this.heatmap = Matrix<double>.Build.Dense(size, size, 1);
            this.scoremap = Matrix<double>.Build.Dense(size, size, 1);
            this.buildingScores = new Dictionary<int, double>();
        }


        private bool IsOccupied(int x, int y, ExtendedBuilding b, int key)
        {
            //int bordercheck = w * h;
            if (x + b.width - 1 >= this.size || y + b.height - 1 >= this.size)
            {
                return true;
            }
            if (this.tile.SubMatrix(y, b.height, x, b.width).RowSums().Sum() == 0)
            {
                if (GlobalVar.PlaceAdjacent)
                {
                    return false;
                }

                int topleftx = x - b.buffer;
                if (topleftx < 0) { topleftx = 0; }
                int toplefty = y - b.buffer;
                if (toplefty < 0) { toplefty = 0; }
                int bottomrightx = x + b.width + b.buffer - 1;
                if (bottomrightx >= this.size) { bottomrightx = this.size - 1; }
                int bottomrighty = y + b.height + b.buffer - 1;
                if (bottomrighty >= this.size) { bottomrighty = this.size - 1; }
                //Matrix<double> t = Matrix<double>.Build.DenseOfMatrix(this.tile.SubMatrix((x - 1) < 0 ? 0 : x - 1, (x - 1 + w + 2) >= size ? ((x - 1 + w + 1) >= size ? w : w + 1) : w + 2,
                //    (y - 1) < 0 ? 0 : y - 1, (y - 1 + h + 2) >= size ? ((y - 1 + h + 1) >= size ? h : h + 1) : h + 2));
                Matrix<double> t = Matrix<double>.Build.DenseOfMatrix(this.tile.SubMatrix(toplefty, bottomrighty - toplefty + 1, topleftx, bottomrightx - topleftx + 1));
                //t.Modulus(10);
                if (t.Find(s => s % 100 == key % 100) == null)
                {
                    return false;
                }
            }

            return true;
        }

        private bool IsOccupied(int x, int y, int w, int h)
        {
            //int bordercheck = w * h;
            if (x + w - 1 >= this.size || y + h - 1 >= this.size)
            {
                return true;
            }
            if (this.tile.SubMatrix(x, w, y, h).RowSums().Sum() == 0)
            {
                return false;
            }

            return true;
        }

        public void AddBuilding(int x, int y, ExtendedBuilding b, int key)
        {
            for (int i = x; i < x + b.width && i < this.size; i++)
            {
                for (int j = y; j < y + b.height && j < this.size; j++)
                {
                    this.tile[j, i] = key;
                    AddDamage(b, j, i, key);
                }
            }
        }

        public void AddBuilding(ExtendedBuilding b)
        {
            for (int i = b.pos.Item2; i < b.pos.Item2 + b.width && i < this.size; i++)
            {
                for (int j = b.pos.Item1; j < b.pos.Item1 + b.height && j < this.size; j++)
                {
                    this.tile[j, i] = b.keys[0];
                    AddDamage(b, j, i, b.keys[0]);
                }
            }
        }

        private void AddDamage(ExtendedBuilding b, int x, int y, int key)
        {
            for (int i = x - b.aoe + 1; i <= x + b.aoe - 1; i++)
            {
                for (int j = y - b.aoe + 1; j <= y + b.aoe - 1; j++)
                {
                    if (i >= 0 && i < GlobalVar.TileSize && j >= 0 && j < GlobalVar.TileSize && (((i - x + 1) * (i - x + 1)) + (j - y + 1) * (j - y + 1)) <= (b.aoe * b.aoe))
                    {
                        this.heatmap[i, j] += b.dmg;
                        this.scoremap[i, j] += b.dmg / (this.tile[i, j] % 100 == key % 100 ? 10 : 1);
                    }
                }
            }
        }

        public bool AddBuilding(ExtendedBuilding b, int key)
        {
            //int tries = maxRandomTries;

            //int x = random.Next(3, GlobalVar.TileSize - 6);
            //int y = random.Next(3, GlobalVar.TileSize - 6);
            //int x;
            //int y;
            foreach (var point in this.scoremap.EnumerateIndexed().OrderByDescending(a => a.Item3))
            {
                if (point.Item1 >= 3 && point.Item1 <= GlobalVar.TileSize - 6 && point.Item2 >= 3 && point.Item2 <= GlobalVar.TileSize - 6)//this.tile.EnumerateIndexed().Count(a => (a.Item3 == GlobalVar.BaseShape)) > 0)
                {
                    if (!IsOccupied(point.Item1, point.Item2, b, key))
                    {
                        AddBuilding(point.Item1, point.Item2, b, key);
                        return true;
                    }
                }
            }

            //foreach (var point in this.tile.EnumerateIndexed(Zeros.Include))
            //{

            //    while (IsOccupied(x, y, b, key) && tries > 0)
            //    {
            //        tries--;
            //        x = random.Next(3, GlobalVar.TileSize - 6);
            //        y = random.Next(3, GlobalVar.TileSize - 6);
            //    }
            //}

            //if (tries > 0)
            //{
            //    AddBuilding(x, y, b, key);
            //    return true;
            //}
            Console.WriteLine("failed to find spot");
            return false;
        }

        public double ScoreBuilding(ExtendedBuilding b, int key)
        {
            double score = 0;
            for (int i = 0; i < scoremap.ColumnCount; i++)
            {
                for (int j = 0; j < scoremap.RowCount; j++)
                {
                    if (this.tile[j, i] == key)
                    {
                        double rawscore = scoremap.SubMatrix(j, b.height, i, b.width).RowSums().Sum();

                        int topleftx = j - b.buffer;
                        if (topleftx < 0) { topleftx = 0; }
                        int toplefty = i - b.buffer;
                        if (toplefty < 0) { toplefty = 0; }
                        int bottomrightx = j + b.width + b.buffer - 1;
                        if (bottomrightx >= this.size) { bottomrightx = this.size - 1; }
                        int bottomrighty = i + b.height + b.buffer - 1;
                        if (bottomrighty >= this.size) { bottomrighty = this.size - 1; }
                        Matrix<double> t = Matrix<double>.Build.DenseOfMatrix(this.tile.SubMatrix(toplefty, bottomrighty - toplefty + 1, topleftx, bottomrightx - topleftx + 1));
                        HashSet<double> uniques = new HashSet<double>();
                        foreach (double k in t.Enumerate())
                        {
                            uniques.Add(k);
                        }

                        rawscore = rawscore * Math.Pow(Convert.ToDouble(uniques.Count()) / b.weight, Convert.ToDouble(2.0));

                        score = rawscore > GlobalVar.BuildingScoreCutoff ? GlobalVar.BuildingScoreCutoff : rawscore * b.weight;
                        this.buildingScores[key] = score;
                        return score;
                    }
                }
            }
            return score;
        }

        public void DrawTile()
        {

            Console.Write(this.tile.ToString(GlobalVar.TileSize, GlobalVar.TileSize));

        }

        public void PrintScores()
        {
            foreach (KeyValuePair<int, double> kvp in this.buildingScores)
            {
                Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
        }

        public void DrawheatMap()
        {
            Matrix<double> d = Matrix<double>.Build.DenseOfMatrix(this.tile);
            this.heatmap.Divide(100, d);
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    d[i, j] = Math.Floor(d[i, j]);
                }
            }
            Console.Write(d.ToString(GlobalVar.TileSize, GlobalVar.TileSize));
        }

        private void RemoveBuilding(ExtendedBuilding b)
        {
            foreach (int key in b.keys)
            {
                for (int i = 0; i < scoremap.ColumnCount; i++)
                {
                    for (int j = 0; j < scoremap.RowCount; j++)
                    {

                        if (this.tile[j, i] == key)
                        {
                            this.tile[j, i] = GlobalVar.BaseShape;
                        }
                    }
                }
            }
            this.DrawTile();
        }
        public void AddWalls(ExtendedBuilding[] b)
        {
            foreach (ExtendedBuilding t in b)
            {
                if (t.name == "wall")
                {
                    RemoveBuilding(t);
                }
            }

            Matrix<double> d = Matrix<double>.Build.DenseOfMatrix(this.tile);


            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (d[j, i] != GlobalVar.BaseShape)
                    {
                        d[j, i] = GlobalVar.BaseShape;
                    }
                    else
                    {
                        d[j, i] = 1;
                    }

                }
            }
            bool update = true;
            while (update)
            {
                update = false;
                for (int x = 0; x < this.size; x++)
                {
                    for (int y = 0; y < this.size; y++)
                    {
                        int topleftx = x - 2 + 1;
                        if (topleftx < 0) { topleftx = 0; }
                        int toplefty = y - 2 + 1;
                        if (toplefty < 0) { toplefty = 0; }
                        int bottomrightx = x + 2 - 1;
                        if (bottomrightx >= this.size) { bottomrightx = this.size - 1; }
                        int bottomrighty = y + 2 - 1;
                        if (bottomrighty >= this.size) { bottomrighty = this.size - 1; }
                        if (d[x, y] != GlobalVar.BaseShape && !this.IsOccupied(topleftx, toplefty, bottomrightx - topleftx + 1, bottomrighty - toplefty + 1))
                        {
                            d[x, y] = GlobalVar.BaseShape;
                            update = true;
                        }
                    }
                    //Console.Write(d.ToString(GlobalVar.TileSize, GlobalVar.TileSize));
                    //Console.ReadLine();
                }
            }
            //update = true;
            //while (update)
            //{
            //    update = false;
            //    for (int x = 0; x < this.size; x++)
            //    {
            //        for (int y = 0; y < this.size; y++)
            //        {
            //            int topleftx = x - 1;
            //            while (topleftx < 0) { ++topleftx; }
            //            int toplefty = y - 1;
            //            while (toplefty < 0) { ++toplefty; }
            //            int bottomrightx = x + 1;
            //            while (bottomrightx >= this.size) { bottomrightx--; }
            //            int bottomrighty = y + 1;
            //            while (bottomrighty >= this.size) { bottomrighty--; }
            //            if (d[x, y] != GlobalVar.BaseShape && (d.SubMatrix(toplefty, bottomrighty - toplefty + 1, topleftx, bottomrightx - topleftx + 1).ColumnSums().Sum() > 7 ||
            //                d.SubMatrix(toplefty, bottomrighty - toplefty + 1, topleftx, bottomrightx - topleftx + 1).ColumnSums().Sum() < 2))
            //            {
            //                d[x, y] = GlobalVar.BaseShape;
            //                update = true;

            //            }
            //        }
            //        //Console.Write(d.ToString(GlobalVar.TileSize, GlobalVar.TileSize));
            //        //Console.ReadLine();
            //    }
            //}
            d = d.Multiply(11);
            Console.Write(d.ToString(GlobalVar.TileSize, GlobalVar.TileSize));
        }


        public void Mutate(Tile pair, List<ExtendedBuilding> b)
        {

            Matrix<double> newtile = Matrix<double>.Build.DenseOfMatrix(this.tile);
            this.tile.Clear();
            heatmap = Matrix<double>.Build.Dense(size, size, 1);
            scoremap = Matrix<double>.Build.Dense(size, size, 1);
            int minkey = this.buildingScores.OrderBy(i => i.Value).First().Key;

            foreach (KeyValuePair<int, double> kvp in this.buildingScores.OrderByDescending(i => i.Value))
            {
                if (kvp.Key != minkey)
                {


                    if (this.buildingScores[kvp.Key] >= pair.buildingScores[kvp.Key])
                    {
                        this.AddBuilding(newtile, kvp.Key, b);
                    }
                    else if (this.buildingScores[kvp.Key] < pair.buildingScores[kvp.Key])
                    {
                        this.AddBuilding(pair.tile, kvp.Key, b);
                    }
                }
                else
                {
                    foreach (ExtendedBuilding bb in b)
                    {
                        if (bb.keys.Contains(kvp.Key))
                        {
                            AddBuilding(bb, kvp.Key);
                        }
                    }
                }
            }



            return;

        }
        private void AddBuilding(Matrix<double> sourceLayout, int key, List<ExtendedBuilding> b)
        {
            for (int i = 0; i < this.size; i++)
            {
                for (int j = 0; j < this.size; j++)
                {
                    if (sourceLayout[i, j] == key)
                    {
                        foreach (ExtendedBuilding bb in b)
                        {
                            if (bb.keys.Contains(key))
                            {
                                if (!IsOccupied(j, i, bb, key))
                                {
                                    AddBuilding(j, i, bb, key);
                                    return;
                                }
                                else
                                {
                                    AddBuilding(bb, key);
                                    return;
                                }
                            }
                        }

                    }
                }
            }
        }
    }
}
