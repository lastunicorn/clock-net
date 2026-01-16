// ClockNet
// Copyright (C) 2010 Dust in the Wind
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using DustInTheWind.ClockNet.Core.Shapes;

internal class RimDrawingCoordinator
{
    private readonly Matrix initialMatrix;

    public Graphics Graphics { get; }

    public float Diameter { get; set; }

    public float Angle { get; set; }

    public float OffsetAngle { get; set; }

    public uint MaxCoverageCount { get; set; }

    public float MaxCoverageAngle { get; set; }

    public bool Repeat { get; internal set; }

    public int SkipIndex { get; set; }

    public float DistanceFromEdge { get; set; }

    public RimItemOrientation Orientation { get; set; }

    public int Index { get; private set; }

    public RimDrawingCoordinator(Graphics graphics)
    {
        Graphics = graphics ?? throw new ArgumentNullException(nameof(graphics));
        initialMatrix = graphics.Transform;
        Index = -1;
    }

    public bool MoveNext()
    {
        float angleDegrees;

        while (true)
        {
            Index++;

            if (!Repeat && Index > 0)
                return false;

            if (MaxCoverageCount > 0 && Index + 1 > MaxCoverageCount)
                return false;

            angleDegrees = OffsetAngle + (Index * Angle);
            if (MaxCoverageAngle > 0 && angleDegrees - OffsetAngle >= MaxCoverageAngle)
                return false;

            bool shouldSkip = SkipIndex > 0 && (Index + 1) % SkipIndex == 0;

            if (!shouldSkip)
                break;
        }

        Graphics.Transform = initialMatrix;

        ApplyRotation(angleDegrees);
        ApplyTranslation();
        ApplyOrientation(angleDegrees);

        return true;
    }

    private void ApplyRotation(float angleDegrees)
    {
        Graphics.RotateTransform(angleDegrees);
    }

    private void ApplyTranslation()
    {
        float radius = Diameter / 2;
        float distanceFromCenter = radius - DistanceFromEdge;

        Graphics.TranslateTransform(0f, -distanceFromCenter);
    }

    private void ApplyOrientation(float angleDegrees)
    {
        switch (Orientation)
        {
            case RimItemOrientation.FaceCenter:
                break;

            case RimItemOrientation.FaceOut:
                Graphics.RotateTransform(180);
                break;

            default:
            case RimItemOrientation.Normal:
                Graphics.RotateTransform(-angleDegrees);
                break;
        }
    }

    public void Reset()
    {
        Index = -1;
    }
}