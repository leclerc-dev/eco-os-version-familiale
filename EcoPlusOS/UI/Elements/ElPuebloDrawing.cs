﻿using System.Drawing;
using Cosmos.System.Graphics;
using EcoPlusOS.UI.Core;
using Point = Cosmos.System.Graphics.Point;

namespace EcoPlusOS.UI.Elements
{
    public class ElPuebloDrawing : UIElement
    {
        #region Bitmaps
        public static readonly Bitmap ElPuebloBitmap = new Bitmap(64, 64, new byte[]
        {
            0x93, 0xb8, 0xde, 0xff, 0x92, 0xbe, 0xe4, 0xff, 0x91, 0xc6, 0xe4, 0xff, 0x96, 0xc5, 0xe1, 0xff, 0xba, 0xda, 0xec, 0xff, 0xb8, 0xde, 0xee, 0xff, 0x9f, 0xad, 0xb4, 0xff, 0x70, 0x51, 0x6d, 0xff, 0x82, 0x83, 0x9a, 0xff, 0xb3, 0xcf, 0xd8, 0xff, 0xc1, 0xec, 0xf4, 0xff, 0xbe, 0xe3, 0xe8, 0xff, 0x8e, 0x8d, 0x9b, 0xff, 0x3b, 0x47, 0x64, 0xff, 0x16, 0x1a, 0x25, 0xff, 0x0a, 0x08, 0x0d, 0xff, 0x0c, 0x0b, 0x11, 0xff, 0x0a, 0x0a, 0x10, 0xff, 0x12, 0x14, 0x26, 0xff, 0x2e, 0x3c, 0x5b, 0xff, 0x88, 0x9a, 0xb3, 0xff, 0xb1, 0xbe, 0xce, 0xff, 0x90, 0x96, 0xa3, 0xff, 0xb5, 0xad, 0xab, 0xff, 0xa8, 0xd4, 0xd9, 0xff, 0x17, 0xe4, 0xed, 0xff, 0x18, 0xe4, 0xed, 0xff, 0x44, 0xe5, 0xf0, 0xff, 0xb0, 0xf6, 0xfa, 0xff, 0xaa, 0xf7, 0xf9, 0xff, 0xa1, 0xee, 0xf6, 0xff, 0xa0, 0xae, 0xbf, 0xff,
  0xa4, 0xc7, 0xe3, 0xff, 0xa4, 0xcf, 0xe6, 0xff, 0xa0, 0xcf, 0xe8, 0xff, 0x95, 0xc6, 0xe5, 0xff, 0x9f, 0xd1, 0xe7, 0xff, 0xb9, 0xd9, 0xe8, 0xff, 0xde, 0xdf, 0xdf, 0xff, 0x9d, 0x88, 0x9f, 0xff, 0x7d, 0x8e, 0xb8, 0xff, 0xba, 0xcc, 0xd8, 0xff, 0xdd, 0xed, 0xf6, 0xff, 0xc1, 0xcc, 0xd6, 0xff, 0x2f, 0x2e, 0x3c, 0xff, 0x0a, 0x08, 0x0d, 0xff, 0x02, 0x01, 0x03, 0xff, 0x01, 0x01, 0x01, 0xff, 0x07, 0x06, 0x08, 0xff, 0x01, 0x02, 0x03, 0xff, 0x01, 0x01, 0x02, 0xff, 0x02, 0x02, 0x0a, 0xff, 0x19, 0x22, 0x4c, 0xff, 0x81, 0x9f, 0xb3, 0xff, 0xc7, 0xd4, 0xe3, 0xff, 0xde, 0xe2, 0xe7, 0xff, 0x99, 0xd6, 0xdc, 0xff, 0x2a, 0xcb, 0xd5, 0xff, 0x1f, 0xe2, 0xed, 0xff, 0x5a, 0xf3, 0xf8, 0xff, 0xc9, 0xf8, 0xfb, 0xff, 0xd5, 0xf4, 0xf9, 0xff, 0x7b, 0xc6, 0xe6, 0xff, 0x98, 0xb2, 0xbe, 0xff,
  0x9c, 0xb7, 0xcc, 0xff, 0xa1, 0xcb, 0xdb, 0xff, 0x8b, 0xae, 0xd2, 0xff, 0xce, 0xd1, 0xd8, 0xff, 0xa9, 0xc3, 0xaf, 0xff, 0xaf, 0xc9, 0xc7, 0xff, 0x99, 0x9f, 0xa8, 0xff, 0xa4, 0xb9, 0xd5, 0xff, 0xa1, 0xad, 0xb9, 0xff, 0xb7, 0xbf, 0xcf, 0xff, 0xca, 0xde, 0xeb, 0xff, 0x49, 0x4d, 0x5d, 0xff, 0x06, 0x03, 0x05, 0xff, 0x03, 0x05, 0x0d, 0xff, 0x02, 0x04, 0x0e, 0xff, 0x01, 0x01, 0x0e, 0xff, 0x00, 0x01, 0x08, 0xff, 0x02, 0x02, 0x09, 0xff, 0x08, 0x0f, 0x30, 0xff, 0x33, 0x4a, 0x80, 0xff, 0x7c, 0xaa, 0xe2, 0xff, 0x48, 0x7a, 0xad, 0xff, 0xbe, 0xc5, 0xc6, 0xff, 0xf6, 0xfb, 0xfb, 0xff, 0xc0, 0xd5, 0xe2, 0xff, 0x9f, 0x9e, 0xad, 0xff, 0xd4, 0xe2, 0xe5, 0xff, 0xe7, 0xf5, 0xf8, 0xff, 0xf0, 0xf9, 0xfa, 0xff, 0xe9, 0xef, 0xf4, 0xff, 0x99, 0xc6, 0xec, 0xff, 0xa9, 0xc5, 0xd2, 0xff,
  0x94, 0xb7, 0xd0, 0xff, 0xac, 0xce, 0xdc, 0xff, 0x7a, 0x8e, 0xd0, 0xff, 0xb6, 0xc5, 0xd1, 0xff, 0x96, 0xa1, 0xa1, 0xff, 0x7f, 0xb1, 0xba, 0xff, 0x51, 0xb1, 0xe5, 0xff, 0x71, 0x91, 0xbc, 0xff, 0x83, 0xa6, 0xbd, 0xff, 0xd4, 0xd2, 0xb4, 0xff, 0x9e, 0xa2, 0xab, 0xff, 0x0a, 0x08, 0x0e, 0xff, 0x02, 0x04, 0x15, 0xff, 0x2e, 0x52, 0xa6, 0xff, 0x41, 0x74, 0xcd, 0xff, 0x3b, 0x78, 0xd2, 0xff, 0x41, 0x7e, 0xcc, 0xff, 0x3d, 0x70, 0xb0, 0xff, 0x60, 0xa5, 0xec, 0xff, 0xa4, 0xd4, 0xf8, 0xff, 0xc6, 0xec, 0xfb, 0xff, 0x8c, 0xc0, 0xed, 0xff, 0x69, 0x7a, 0x8a, 0xff, 0xdf, 0xf1, 0xf1, 0xff, 0xe4, 0xf5, 0xf8, 0xff, 0xec, 0xf0, 0xf1, 0xff, 0xf7, 0xf9, 0xfa, 0xff, 0xf8, 0xf8, 0xfb, 0xff, 0xea, 0xec, 0xec, 0xff, 0xdc, 0xdc, 0xdf, 0xff, 0xee, 0xf4, 0xf9, 0xff, 0xbc, 0xc9, 0xd4, 0xff,
  0xa3, 0xc2, 0xde, 0xff, 0xc5, 0xe8, 0xf0, 0xff, 0xb8, 0xe6, 0xee, 0xff, 0xb8, 0xe6, 0xef, 0xff, 0xdc, 0xe8, 0xf1, 0xff, 0x78, 0xdc, 0xe4, 0xff, 0x77, 0xc5, 0xe3, 0xff, 0x61, 0xb3, 0xd9, 0xff, 0x63, 0xa0, 0xd1, 0xff, 0x9f, 0xc8, 0xc9, 0xff, 0x51, 0x54, 0x64, 0xff, 0x04, 0x03, 0x06, 0xff, 0x09, 0x0f, 0x36, 0xff, 0x44, 0x80, 0xd9, 0xff, 0x59, 0xa1, 0xf0, 0xff, 0x5e, 0xaf, 0xfb, 0xff, 0x61, 0xb3, 0xfb, 0xff, 0x66, 0xb7, 0xfb, 0xff, 0x7b, 0xc2, 0xfa, 0xff, 0xb0, 0xde, 0xfc, 0xff, 0xac, 0xdb, 0xf9, 0xff, 0x8f, 0xc7, 0xfa, 0xff, 0x24, 0x44, 0x8e, 0xff, 0x82, 0xa5, 0xb1, 0xff, 0x98, 0xb0, 0xd1, 0xff, 0x8c, 0x8d, 0xba, 0xff, 0x8f, 0xa3, 0xaf, 0xff, 0xd6, 0xda, 0xdd, 0xff, 0xc3, 0xca, 0xcd, 0xff, 0xc2, 0xc3, 0xc3, 0xff, 0xe7, 0xe8, 0xe8, 0xff, 0xa9, 0xd1, 0xe9, 0xff,
  0xa2, 0xbe, 0xd5, 0xff, 0xd1, 0xea, 0xef, 0xff, 0xbc, 0xe4, 0xec, 0xff, 0xcc, 0xea, 0xf0, 0xff, 0xd8, 0xef, 0xf3, 0xff, 0x91, 0xeb, 0xf3, 0xff, 0x81, 0xc7, 0xf1, 0xff, 0x99, 0xdc, 0xef, 0xff, 0xa8, 0xda, 0xeb, 0xff, 0xab, 0xd7, 0xe4, 0xff, 0x1a, 0x21, 0x33, 0xff, 0x02, 0x01, 0x04, 0xff, 0x1d, 0x2b, 0x64, 0xff, 0x4d, 0x8d, 0xdf, 0xff, 0x57, 0xa1, 0xef, 0xff, 0x63, 0xb1, 0xfb, 0xff, 0x6f, 0xbf, 0xfa, 0xff, 0x77, 0xc5, 0xfb, 0xff, 0x79, 0xc7, 0xfa, 0xff, 0x76, 0xc5, 0xf9, 0xff, 0x79, 0xc3, 0xfb, 0xff, 0x77, 0xbb, 0xf8, 0xff, 0x18, 0x2d, 0x7d, 0xff, 0x57, 0x81, 0x99, 0xff, 0x57, 0x9d, 0xbf, 0xff, 0x99, 0xcb, 0xdc, 0xff, 0xb2, 0xd3, 0xde, 0xff, 0x94, 0x9d, 0xa7, 0xff, 0x9e, 0x6c, 0x8b, 0xff, 0x99, 0xae, 0xb9, 0xff, 0x7c, 0x98, 0xba, 0xff, 0x9d, 0xc1, 0xd4, 0xff,
  0x79, 0x91, 0xa6, 0xff, 0xa1, 0xd2, 0xdf, 0xff, 0x97, 0xd2, 0xdf, 0xff, 0xa3, 0xcd, 0xd7, 0xff, 0xb1, 0xc6, 0xc9, 0xff, 0x6b, 0x93, 0x9c, 0xff, 0x3b, 0x6b, 0x9e, 0xff, 0x83, 0xd5, 0xf0, 0xff, 0xc9, 0xdd, 0xf0, 0xff, 0xc6, 0xd7, 0xda, 0xff, 0x11, 0x17, 0x1b, 0xff, 0x02, 0x01, 0x04, 0xff, 0x1c, 0x29, 0x67, 0xff, 0x54, 0x8c, 0xde, 0xff, 0x60, 0xa9, 0xf6, 0xff, 0x6a, 0xba, 0xfb, 0xff, 0x84, 0xcd, 0xfc, 0xff, 0x7a, 0xc9, 0xfb, 0xff, 0x76, 0xc7, 0xfb, 0xff, 0x69, 0xc0, 0xfa, 0xff, 0x56, 0xb2, 0xf9, 0xff, 0x51, 0xa3, 0xef, 0xff, 0x1f, 0x39, 0x87, 0xff, 0x5d, 0x76, 0x7d, 0xff, 0xb7, 0xe7, 0xef, 0xff, 0x8b, 0xb5, 0xc8, 0xff, 0x9f, 0xbe, 0xc7, 0xff, 0x7e, 0xa3, 0xb3, 0xff, 0x7c, 0x71, 0x98, 0xff, 0x71, 0xa4, 0xb4, 0xff, 0x62, 0x9e, 0xcc, 0xff, 0x9b, 0xbc, 0xc8, 0xff,
  0x8c, 0xa7, 0xb8, 0xff, 0xa8, 0xcb, 0xdb, 0xff, 0x5a, 0x74, 0x7b, 0xff, 0x21, 0x26, 0x62, 0xff, 0x07, 0x05, 0x99, 0xff, 0x07, 0x05, 0xb0, 0xff, 0x09, 0x0b, 0xc0, 0xff, 0x11, 0x15, 0x62, 0xff, 0x97, 0x98, 0xa4, 0xff, 0xdb, 0xdb, 0xdc, 0xff, 0x0c, 0x0d, 0x11, 0xff, 0x02, 0x01, 0x02, 0xff, 0x0c, 0x11, 0x44, 0xff, 0x55, 0x83, 0xda, 0xff, 0x63, 0xa9, 0xf5, 0xff, 0x6d, 0xbb, 0xfb, 0xff, 0x7b, 0xc8, 0xfa, 0xff, 0x72, 0xc5, 0xfb, 0xff, 0x6f, 0xc3, 0xfb, 0xff, 0x6a, 0xc0, 0xfb, 0xff, 0x51, 0xb1, 0xf8, 0xff, 0x47, 0x98, 0xe4, 0xff, 0x2a, 0x4b, 0x90, 0xff, 0x40, 0x47, 0x4d, 0xff, 0xe5, 0xed, 0xee, 0xff, 0xeb, 0xf7, 0xf9, 0xff, 0xe4, 0xf2, 0xf4, 0xff, 0xc7, 0xd8, 0xdd, 0xff, 0xa0, 0xb7, 0xbb, 0xff, 0xb3, 0xce, 0xd3, 0xff, 0xb5, 0xd8, 0xe6, 0xff, 0xa2, 0xac, 0xcc, 0xff,
  0x72, 0x94, 0xa5, 0xff, 0x47, 0x6e, 0x83, 0xff, 0x35, 0x36, 0x40, 0xff, 0x09, 0x07, 0x76, 0xff, 0x05, 0x03, 0x72, 0xff, 0x0b, 0x08, 0x64, 0xff, 0x1d, 0x1b, 0x78, 0xff, 0x0d, 0x0a, 0xaf, 0xff, 0x2a, 0x2a, 0x4c, 0xff, 0xdd, 0xe0, 0xe1, 0xff, 0x11, 0x12, 0x13, 0xff, 0x01, 0x01, 0x02, 0xff, 0x14, 0x1b, 0x56, 0xff, 0x55, 0x80, 0xd7, 0xff, 0x53, 0x88, 0xdb, 0xff, 0x5e, 0x9f, 0xe5, 0xff, 0x6c, 0xb5, 0xf0, 0xff, 0x6b, 0xbc, 0xfa, 0xff, 0x66, 0xb7, 0xf9, 0xff, 0x4b, 0x92, 0xda, 0xff, 0x2e, 0x6b, 0xb3, 0xff, 0x3a, 0x70, 0xba, 0xff, 0x3b, 0x68, 0xac, 0xff, 0x0b, 0x15, 0x2b, 0xff, 0xce, 0xdd, 0xe3, 0xff, 0xf2, 0xf9, 0xfa, 0xff, 0xeb, 0xf6, 0xf8, 0xff, 0xd8, 0xe7, 0xe9, 0xff, 0xcf, 0xe8, 0xed, 0xff, 0xc6, 0xe5, 0xed, 0xff, 0xb4, 0xdd, 0xe7, 0xff, 0xad, 0xbc, 0xcb, 0xff,
  0x90, 0xa9, 0xce, 0xff, 0x2f, 0x38, 0x3a, 0xff, 0x40, 0x4b, 0x4d, 0xff, 0x66, 0x66, 0x66, 0xff, 0x82, 0x82, 0x82, 0xff, 0x8b, 0x8c, 0x8c, 0xff, 0x81, 0x81, 0x81, 0xff, 0x2d, 0x2d, 0x2e, 0xff, 0x9c, 0x9c, 0x9c, 0xff, 0x74, 0x79, 0x7b, 0xff, 0x18, 0x1e, 0x46, 0xff, 0x06, 0x05, 0x19, 0xff, 0x22, 0x30, 0x6a, 0xff, 0x48, 0x6f, 0xca, 0xff, 0x43, 0x70, 0xc1, 0xff, 0x38, 0x6c, 0xb3, 0xff, 0x31, 0x6d, 0xbb, 0xff, 0x52, 0xa1, 0xed, 0xff, 0x47, 0x9c, 0xea, 0xff, 0x31, 0x74, 0xc6, 0xff, 0x3d, 0x76, 0xc1, 0xff, 0x2b, 0x63, 0xb4, 0xff, 0x53, 0x8c, 0xd1, 0xff, 0x1c, 0x2d, 0x4d, 0xff, 0xbb, 0xc1, 0xc9, 0xff, 0xd4, 0xe5, 0xe9, 0xff, 0xcd, 0xe8, 0xec, 0xff, 0xc3, 0xe3, 0xe9, 0xff, 0xb2, 0xd9, 0xe2, 0xff, 0xbc, 0xde, 0xe7, 0xff, 0xa7, 0xd8, 0xe5, 0xff, 0xc3, 0xd5, 0xd3, 0xff,
  0x5a, 0x6f, 0x97, 0xff, 0x13, 0x81, 0x96, 0xff, 0x0b, 0xe7, 0xfa, 0xff, 0x27, 0x73, 0x79, 0xff, 0x10, 0x12, 0x12, 0xff, 0x7f, 0xbb, 0xc0, 0xff, 0x1a, 0x1e, 0x1e, 0xff, 0x32, 0x56, 0x57, 0xff, 0x62, 0x63, 0x62, 0xff, 0x35, 0x37, 0x3c, 0xff, 0x2a, 0x3f, 0x84, 0xff, 0x29, 0x39, 0x84, 0xff, 0x28, 0x3b, 0x75, 0xff, 0x4e, 0x88, 0xdb, 0xff, 0x49, 0x79, 0xca, 0xff, 0x3c, 0x71, 0xb4, 0xff, 0x45, 0x94, 0xe1, 0xff, 0x54, 0xa4, 0xf0, 0xff, 0x4f, 0xa4, 0xf1, 0xff, 0x42, 0x96, 0xe8, 0xff, 0x40, 0x88, 0xd4, 0xff, 0x42, 0x8b, 0xdc, 0xff, 0x65, 0xad, 0xef, 0xff, 0x26, 0x3c, 0x65, 0xff, 0x8a, 0x85, 0x96, 0xff, 0xd2, 0xd2, 0xd7, 0xff, 0xe4, 0xf3, 0xf6, 0xff, 0xd2, 0xec, 0xf1, 0xff, 0xc7, 0xe6, 0xec, 0xff, 0xc6, 0xe5, 0xec, 0xff, 0xaa, 0xd9, 0xe3, 0xff, 0xcc, 0xdd, 0xe0, 0xff,
  0x70, 0x94, 0xb5, 0xff, 0x0e, 0x6b, 0x81, 0xff, 0x05, 0xe0, 0xf9, 0xff, 0x25, 0xd7, 0xe3, 0xff, 0x36, 0x86, 0x8c, 0xff, 0x5b, 0xe1, 0xeb, 0xff, 0x45, 0xa3, 0xab, 0xff, 0x41, 0xaf, 0xb7, 0xff, 0x24, 0xd1, 0xe0, 0xff, 0x13, 0x25, 0x2e, 0xff, 0x24, 0x35, 0x6b, 0xff, 0x3e, 0x5f, 0xb1, 0xff, 0x2a, 0x3d, 0x75, 0xff, 0x5f, 0xa0, 0xee, 0xff, 0x57, 0xa0, 0xf1, 0xff, 0x59, 0xa6, 0xf2, 0xff, 0x5b, 0xab, 0xf7, 0xff, 0x51, 0x9b, 0xef, 0xff, 0x4c, 0x9a, 0xee, 0xff, 0x3b, 0x8f, 0xe8, 0xff, 0x53, 0xab, 0xf9, 0xff, 0x5a, 0xaf, 0xf9, 0xff, 0x59, 0xa6, 0xf0, 0xff, 0x22, 0x39, 0x62, 0xff, 0x7e, 0x89, 0x9e, 0xff, 0xcd, 0xe0, 0xed, 0xff, 0xe8, 0xf7, 0xf9, 0xff, 0xe3, 0xf5, 0xf9, 0xff, 0xda, 0xf0, 0xf5, 0xff, 0xd3, 0xec, 0xf2, 0xff, 0xc5, 0xe6, 0xed, 0xff, 0xde, 0xe7, 0xe9, 0xff,
  0x70, 0xad, 0xd0, 0xff, 0x1a, 0x51, 0x6e, 0xff, 0x11, 0xa1, 0xc8, 0xff, 0x3b, 0x5c, 0x5e, 0xff, 0x64, 0x75, 0x77, 0xff, 0x87, 0xa1, 0xb1, 0xff, 0x81, 0x83, 0x85, 0xff, 0x4a, 0x53, 0x56, 0xff, 0x17, 0x80, 0x97, 0xff, 0x1c, 0x2a, 0x36, 0xff, 0x16, 0x1c, 0x40, 0xff, 0x44, 0x62, 0xc0, 0xff, 0x44, 0x58, 0x9f, 0xff, 0x63, 0x98, 0xe8, 0xff, 0x68, 0xa9, 0xf8, 0xff, 0x6a, 0xb7, 0xfb, 0xff, 0x5b, 0xa4, 0xf2, 0xff, 0x5a, 0x93, 0xea, 0xff, 0x60, 0xa5, 0xf0, 0xff, 0x3a, 0x81, 0xd7, 0xff, 0x4c, 0xa0, 0xf0, 0xff, 0x4d, 0xa5, 0xf6, 0xff, 0x43, 0x8e, 0xe1, 0xff, 0x1a, 0x2d, 0x5c, 0xff, 0x65, 0x78, 0x85, 0xff, 0xb9, 0xd4, 0xdd, 0xff, 0xc9, 0xda, 0xdf, 0xff, 0xd5, 0xec, 0xf1, 0xff, 0xc8, 0xe9, 0xef, 0xff, 0xcb, 0xea, 0xf1, 0xff, 0xc4, 0xe6, 0xef, 0xff, 0xd0, 0xe5, 0xe9, 0xff,
  0x8b, 0xcb, 0xe8, 0xff, 0x5b, 0x70, 0x90, 0xff, 0x13, 0x6b, 0x96, 0xff, 0x32, 0x60, 0x78, 0xff, 0xa8, 0xb9, 0xc5, 0xff, 0x99, 0xc1, 0xe0, 0xff, 0x63, 0x67, 0x6b, 0xff, 0x1f, 0x90, 0xac, 0xff, 0x34, 0x6b, 0x82, 0xff, 0x29, 0x31, 0x3c, 0xff, 0x03, 0x04, 0x0f, 0xff, 0x3f, 0x58, 0xae, 0xff, 0x56, 0x71, 0xc8, 0xff, 0x5a, 0x8d, 0xdd, 0xff, 0x5b, 0x9f, 0xf1, 0xff, 0x4e, 0xa0, 0xee, 0xff, 0x41, 0x77, 0xbd, 0xff, 0x27, 0x41, 0x7f, 0xff, 0x23, 0x46, 0x80, 0xff, 0x16, 0x2a, 0x56, 0xff, 0x26, 0x4f, 0x87, 0xff, 0x35, 0x77, 0xc2, 0xff, 0x37, 0x78, 0xca, 0xff, 0x12, 0x1d, 0x40, 0xff, 0x62, 0x6c, 0x74, 0xff, 0xa8, 0xaf, 0xb5, 0xff, 0xa3, 0xb5, 0xba, 0xff, 0xd0, 0xea, 0xef, 0xff, 0xd2, 0xec, 0xf0, 0xff, 0xd0, 0xec, 0xf0, 0xff, 0xbc, 0xe6, 0xef, 0xff, 0xa7, 0xc2, 0xd9, 0xff,
  0xa1, 0xd6, 0xf1, 0xff, 0x6e, 0xa2, 0xd1, 0xff, 0x42, 0x66, 0x87, 0xff, 0x15, 0x4c, 0x68, 0xff, 0x55, 0x81, 0x9c, 0xff, 0x5f, 0x97, 0xbf, 0xff, 0x15, 0x5a, 0x81, 0xff, 0x45, 0x56, 0x5e, 0xff, 0x9e, 0xa8, 0xad, 0xff, 0x42, 0x4f, 0x5b, 0xff, 0x01, 0x04, 0x09, 0xff, 0x03, 0x06, 0x15, 0xff, 0x3e, 0x53, 0x92, 0xff, 0x4e, 0x85, 0xd0, 0xff, 0x54, 0x9d, 0xe7, 0xff, 0x34, 0x69, 0xac, 0xff, 0x21, 0x37, 0x69, 0xff, 0x17, 0x27, 0x55, 0xff, 0x25, 0x43, 0x8b, 0xff, 0x14, 0x28, 0x62, 0xff, 0x20, 0x43, 0x81, 0xff, 0x2f, 0x71, 0xb3, 0xff, 0x30, 0x69, 0xb1, 0xff, 0x04, 0x06, 0x14, 0xff, 0x15, 0x12, 0x27, 0xff, 0xa3, 0x6b, 0x90, 0xff, 0x92, 0xc2, 0xca, 0xff, 0x9d, 0xcd, 0xd7, 0xff, 0xb1, 0xdc, 0xe4, 0xff, 0xa1, 0xc8, 0xd8, 0xff, 0x9e, 0xd4, 0xdf, 0xff, 0x9b, 0xc5, 0xd0, 0xff,
  0x94, 0xc5, 0xe2, 0xff, 0x94, 0xc9, 0xec, 0xff, 0x71, 0xb0, 0xdc, 0xff, 0xa7, 0xcf, 0xe1, 0xff, 0xaf, 0xdb, 0xee, 0xff, 0x8e, 0xac, 0xbe, 0xff, 0x86, 0x8f, 0x91, 0xff, 0xc7, 0xdb, 0xdf, 0xff, 0x86, 0x89, 0x97, 0xff, 0x1e, 0x2b, 0x35, 0xff, 0x00, 0x03, 0x07, 0xff, 0x01, 0x03, 0x0b, 0xff, 0x18, 0x20, 0x38, 0xff, 0x48, 0x78, 0xbb, 0xff, 0x53, 0x9a, 0xde, 0xff, 0x3e, 0x80, 0xc5, 0xff, 0x46, 0x81, 0xd0, 0xff, 0x47, 0x80, 0xce, 0xff, 0x43, 0x7a, 0xd0, 0xff, 0x41, 0x83, 0xdb, 0xff, 0x42, 0x93, 0xe0, 0xff, 0x3e, 0x91, 0xd5, 0xff, 0x1c, 0x3b, 0x70, 0xff, 0x02, 0x04, 0x0b, 0xff, 0x04, 0x04, 0x0a, 0xff, 0x1e, 0x29, 0x39, 0xff, 0x93, 0xc1, 0xcc, 0xff, 0xb3, 0xe5, 0xef, 0xff, 0x82, 0xc9, 0xdb, 0xff, 0x67, 0xaa, 0xc5, 0xff, 0x6e, 0x9a, 0xb6, 0xff, 0x7a, 0xa5, 0xb3, 0xff,
  0x75, 0xa4, 0xc3, 0xff, 0xa9, 0xd7, 0xf4, 0xff, 0x6b, 0xb3, 0xde, 0xff, 0xb7, 0xe3, 0xf8, 0xff, 0xb9, 0xe1, 0xf8, 0xff, 0x97, 0xb9, 0xc9, 0xff, 0xd3, 0xed, 0xf0, 0xff, 0xaf, 0xcf, 0xd4, 0xff, 0x23, 0x2f, 0x38, 0xff, 0x03, 0x06, 0x0c, 0xff, 0x02, 0x06, 0x0f, 0xff, 0x01, 0x03, 0x0e, 0xff, 0x03, 0x05, 0x0c, 0xff, 0x2f, 0x49, 0x84, 0xff, 0x53, 0x92, 0xd5, 0xff, 0x4f, 0x99, 0xdd, 0xff, 0x52, 0x9d, 0xe6, 0xff, 0x57, 0xa3, 0xea, 0xff, 0x51, 0x9b, 0xe0, 0xff, 0x46, 0x9b, 0xe5, 0xff, 0x3a, 0x8f, 0xd7, 0xff, 0x31, 0x6c, 0xb0, 0xff, 0x09, 0x11, 0x22, 0xff, 0x03, 0x04, 0x0d, 0xff, 0x01, 0x02, 0x09, 0xff, 0x12, 0x17, 0x1f, 0xff, 0x5e, 0x8c, 0x9c, 0xff, 0x61, 0xca, 0xdf, 0xff, 0x99, 0xd8, 0xe7, 0xff, 0x84, 0xd2, 0xe4, 0xff, 0x69, 0xc4, 0xdb, 0xff, 0x69, 0xad, 0xc4, 0xff,
  0x65, 0x9a, 0xbb, 0xff, 0xb0, 0xe0, 0xf7, 0xff, 0x92, 0xcb, 0xed, 0xff, 0xaa, 0xda, 0xf7, 0xff, 0x94, 0xc8, 0xea, 0xff, 0x7e, 0xa0, 0xb0, 0xff, 0xd4, 0xd6, 0xd8, 0xff, 0xab, 0xbe, 0xc2, 0xff, 0x09, 0x0d, 0x14, 0xff, 0x01, 0x03, 0x08, 0xff, 0x01, 0x02, 0x09, 0xff, 0x01, 0x04, 0x0a, 0xff, 0x09, 0x10, 0x1f, 0xff, 0x36, 0x57, 0x94, 0xff, 0x4f, 0x7f, 0xbd, 0xff, 0x55, 0x96, 0xd5, 0xff, 0x53, 0x9d, 0xe3, 0xff, 0x5a, 0xa8, 0xed, 0xff, 0x59, 0xab, 0xf0, 0xff, 0x44, 0x9d, 0xe6, 0xff, 0x34, 0x7b, 0xc2, 0xff, 0x1d, 0x3a, 0x6b, 0xff, 0x10, 0x1b, 0x23, 0xff, 0x02, 0x05, 0x09, 0xff, 0x01, 0x03, 0x0a, 0xff, 0x03, 0x05, 0x0d, 0xff, 0x24, 0x34, 0x3c, 0xff, 0x97, 0xc4, 0xce, 0xff, 0x70, 0xc6, 0xda, 0xff, 0x65, 0xbf, 0xd4, 0xff, 0x74, 0xcc, 0xe0, 0xff, 0x75, 0xb9, 0xcd, 0xff,
  0x67, 0x8b, 0xb5, 0xff, 0x92, 0xd0, 0xec, 0xff, 0xae, 0xdd, 0xf4, 0xff, 0xa2, 0xce, 0xee, 0xff, 0x64, 0x9f, 0xbe, 0xff, 0x46, 0x61, 0x6d, 0xff, 0x97, 0x87, 0x8d, 0xff, 0x58, 0x73, 0x7a, 0xff, 0x3f, 0x4e, 0x53, 0xff, 0x04, 0x06, 0x0f, 0xff, 0x03, 0x05, 0x0f, 0xff, 0x0d, 0x12, 0x1a, 0xff, 0x0e, 0x18, 0x23, 0xff, 0x3a, 0x67, 0x98, 0xff, 0x52, 0x84, 0xbc, 0xff, 0x57, 0x8e, 0xc6, 0xff, 0x51, 0x91, 0xd0, 0xff, 0x4d, 0x94, 0xd5, 0xff, 0x44, 0x87, 0xca, 0xff, 0x36, 0x77, 0xb8, 0xff, 0x23, 0x55, 0x8f, 0xff, 0x19, 0x35, 0x5c, 0xff, 0x24, 0x39, 0x46, 0xff, 0x14, 0x20, 0x26, 0xff, 0x05, 0x0b, 0x12, 0xff, 0x07, 0x0d, 0x13, 0xff, 0x18, 0x21, 0x23, 0xff, 0x2b, 0x3b, 0x3e, 0xff, 0x4d, 0x6b, 0x71, 0xff, 0x64, 0xac, 0xbc, 0xff, 0x61, 0xb3, 0xca, 0xff, 0x5d, 0xa2, 0xc0, 0xff,
  0x7e, 0xac, 0xc9, 0xff, 0x93, 0xcb, 0xe9, 0xff, 0xb0, 0xde, 0xf5, 0xff, 0x90, 0xc8, 0xe4, 0xff, 0x3d, 0x65, 0x6d, 0xff, 0x5f, 0x84, 0x81, 0xff, 0x85, 0x4f, 0x7b, 0xff, 0x69, 0x6e, 0x7c, 0xff, 0x74, 0x93, 0x93, 0xff, 0x4e, 0x68, 0x6c, 0xff, 0x44, 0x5c, 0x60, 0xff, 0x25, 0x3a, 0x3e, 0xff, 0x6c, 0x8f, 0x95, 0xff, 0x7b, 0xa7, 0xbd, 0xff, 0x78, 0xa7, 0xca, 0xff, 0x7b, 0xa8, 0xd1, 0xff, 0x59, 0x84, 0xb3, 0xff, 0x39, 0x5c, 0x8a, 0xff, 0x28, 0x45, 0x70, 0xff, 0x19, 0x37, 0x5b, 0xff, 0x24, 0x49, 0x66, 0xff, 0x1e, 0x48, 0x5e, 0xff, 0x2f, 0x4d, 0x54, 0xff, 0x2f, 0x48, 0x4a, 0xff, 0x45, 0x61, 0x62, 0xff, 0x44, 0x61, 0x61, 0xff, 0x41, 0x5e, 0x5b, 0xff, 0x3b, 0x52, 0x51, 0xff, 0x35, 0x46, 0x43, 0xff, 0x37, 0x4a, 0x4c, 0xff, 0x71, 0xa6, 0xb4, 0xff, 0x6f, 0xa7, 0xc0, 0xff,
  0x82, 0xc2, 0xe6, 0xff, 0x9b, 0xd6, 0xf1, 0xff, 0xaf, 0xdc, 0xf4, 0xff, 0x64, 0xa1, 0xb9, 0xff, 0x56, 0x87, 0x87, 0xff, 0x45, 0x63, 0x62, 0xff, 0x4d, 0x65, 0x60, 0xff, 0x67, 0x89, 0x85, 0xff, 0x7b, 0x9e, 0x9e, 0xff, 0x92, 0xb6, 0xb7, 0xff, 0x92, 0xb6, 0xb7, 0xff, 0x82, 0xa6, 0xa7, 0xff, 0x70, 0x92, 0x93, 0xff, 0x71, 0x8d, 0x8f, 0xff, 0x51, 0x95, 0x9e, 0xff, 0x51, 0x6d, 0x80, 0xff, 0x28, 0x97, 0xa8, 0xff, 0x1c, 0x93, 0xa0, 0xff, 0x18, 0xcb, 0xdb, 0xff, 0x21, 0xc6, 0xcf, 0xff, 0x14, 0xb2, 0xc4, 0xff, 0x14, 0xbb, 0xcc, 0xff, 0x1a, 0xc5, 0xd6, 0xff, 0x1d, 0x92, 0x9a, 0xff, 0x3e, 0x8f, 0x95, 0xff, 0x6f, 0x8a, 0x8a, 0xff, 0x54, 0x73, 0x70, 0xff, 0x40, 0x64, 0x64, 0xff, 0x46, 0x59, 0x57, 0xff, 0x3e, 0x50, 0x4c, 0xff, 0x38, 0x50, 0x50, 0xff, 0x6b, 0x8c, 0x9b, 0xff,
  0x81, 0xc4, 0xe7, 0xff, 0xb0, 0xe1, 0xf7, 0xff, 0x89, 0xc1, 0xe0, 0xff, 0x35, 0x64, 0x71, 0xff, 0x2c, 0x6b, 0x6b, 0xff, 0x22, 0x55, 0x55, 0xff, 0x2b, 0x50, 0x51, 0xff, 0x3a, 0x69, 0x6a, 0xff, 0x7e, 0xa2, 0xa2, 0xff, 0x9e, 0xc4, 0xc6, 0xff, 0x6b, 0x96, 0x98, 0xff, 0x1b, 0xbd, 0xcc, 0xff, 0x16, 0xcb, 0xdb, 0xff, 0x21, 0x88, 0x93, 0xff, 0x18, 0xc2, 0xd5, 0xff, 0x39, 0x49, 0x4c, 0xff, 0x16, 0xb6, 0xd1, 0xff, 0x15, 0xa1, 0xba, 0xff, 0x13, 0x84, 0x9f, 0xff, 0x16, 0x5e, 0x6c, 0xff, 0x13, 0x9f, 0xc0, 0xff, 0x15, 0x6e, 0x88, 0xff, 0x12, 0xae, 0xd9, 0xff, 0x17, 0x8f, 0xa7, 0xff, 0x2b, 0x7b, 0x86, 0xff, 0x5c, 0x72, 0x70, 0xff, 0x26, 0x98, 0xa5, 0xff, 0x14, 0xcb, 0xdd, 0xff, 0x20, 0x99, 0xa3, 0xff, 0x53, 0x64, 0x62, 0xff, 0x51, 0x66, 0x63, 0xff, 0x39, 0x52, 0x63, 0xff,
  0x8d, 0xd2, 0xef, 0xff, 0xa8, 0xdd, 0xf8, 0xff, 0x5c, 0xa1, 0xba, 0xff, 0x26, 0x49, 0x51, 0xff, 0x17, 0xd5, 0xeb, 0xff, 0x0f, 0x9f, 0xad, 0xff, 0x17, 0x82, 0x8b, 0xff, 0x17, 0xae, 0xc0, 0xff, 0x73, 0x99, 0x9c, 0xff, 0x9d, 0xc3, 0xc5, 0xff, 0x5d, 0x87, 0x8a, 0xff, 0x15, 0xaf, 0xca, 0xff, 0x10, 0x37, 0x44, 0xff, 0x13, 0xaa, 0xca, 0xff, 0x16, 0xaf, 0xd5, 0xff, 0x25, 0x33, 0x36, 0xff, 0x15, 0xa1, 0xd0, 0xff, 0x15, 0x8a, 0xbc, 0xff, 0x16, 0x6f, 0x97, 0xff, 0x12, 0x40, 0x4b, 0xff, 0x11, 0x86, 0xc0, 0xff, 0x0f, 0x6e, 0x9c, 0xff, 0x0f, 0x94, 0xdf, 0xff, 0x16, 0x79, 0xa2, 0xff, 0x1c, 0x5e, 0x74, 0xff, 0x30, 0x43, 0x44, 0xff, 0x15, 0x88, 0xab, 0xff, 0x14, 0x45, 0x4f, 0xff, 0x11, 0x99, 0xb1, 0xff, 0x45, 0x6f, 0x72, 0xff, 0x7c, 0x8f, 0x8c, 0xff, 0x3f, 0x4e, 0x4e, 0xff,
  0x92, 0xd5, 0xf0, 0xff, 0x7c, 0xc3, 0xe4, 0xff, 0x5d, 0xa1, 0xa8, 0xff, 0x36, 0x5c, 0x63, 0xff, 0x15, 0xbd, 0xef, 0xff, 0x13, 0x9d, 0xc1, 0xff, 0x1a, 0x5d, 0x66, 0xff, 0x14, 0x9e, 0xbd, 0xff, 0x5d, 0x7b, 0x7a, 0xff, 0x8a, 0xaa, 0xac, 0xff, 0x54, 0x78, 0x7d, 0xff, 0x0e, 0xaa, 0xef, 0xff, 0x17, 0xa0, 0xd4, 0xff, 0x11, 0x48, 0x58, 0xff, 0x15, 0x94, 0xd4, 0xff, 0x1c, 0x4c, 0x6e, 0xff, 0x18, 0x8e, 0xd7, 0xff, 0x11, 0x6e, 0xb0, 0xff, 0x0f, 0x74, 0xc7, 0xff, 0x1d, 0x8b, 0xc6, 0xff, 0x17, 0x7a, 0xbe, 0xff, 0x1b, 0x8b, 0xe0, 0xff, 0x17, 0x85, 0xcd, 0xff, 0x18, 0x68, 0x98, 0xff, 0x10, 0x73, 0xc9, 0xff, 0x15, 0x90, 0xe2, 0xff, 0x15, 0x79, 0xaa, 0xff, 0x18, 0x41, 0x53, 0xff, 0x12, 0x7f, 0xa3, 0xff, 0x46, 0x78, 0x81, 0xff, 0x8c, 0x9c, 0x98, 0xff, 0x5c, 0x6b, 0x69, 0xff,
  0x85, 0xca, 0xf0, 0xff, 0x45, 0x98, 0xb7, 0xff, 0x7c, 0xba, 0xb6, 0xff, 0x52, 0x75, 0x7a, 0xff, 0x1b, 0x99, 0xd9, 0xff, 0x0e, 0x2c, 0x40, 0xff, 0x12, 0x34, 0x40, 0xff, 0x12, 0x85, 0xbd, 0xff, 0x22, 0x5d, 0x7b, 0xff, 0x35, 0x7d, 0x95, 0xff, 0x46, 0x6a, 0x71, 0xff, 0x14, 0x86, 0xcc, 0xff, 0x1b, 0x29, 0x35, 0xff, 0x41, 0x4c, 0x4e, 0xff, 0x17, 0x4a, 0x68, 0xff, 0x12, 0x5d, 0x9b, 0xff, 0x15, 0x3a, 0x54, 0xff, 0x18, 0x37, 0x48, 0xff, 0x11, 0x2e, 0x49, 0xff, 0x0f, 0x24, 0x33, 0xff, 0x12, 0x20, 0x2a, 0xff, 0x14, 0x23, 0x33, 0xff, 0x22, 0x30, 0x3c, 0xff, 0x1f, 0x2e, 0x36, 0xff, 0x11, 0x2f, 0x4c, 0xff, 0x13, 0x4f, 0x72, 0xff, 0x13, 0x34, 0x47, 0xff, 0x17, 0x7e, 0xcb, 0xff, 0x0b, 0x8d, 0xe6, 0xff, 0x46, 0x6f, 0x76, 0xff, 0x8c, 0x9d, 0x96, 0xff, 0x82, 0x97, 0x90, 0xff,
  0x45, 0xab, 0xd5, 0xff, 0x50, 0xa0, 0xa5, 0xff, 0x9f, 0xd2, 0xcf, 0xff, 0x6a, 0x8a, 0x90, 0xff, 0x1a, 0x82, 0xd0, 0xff, 0x19, 0x8c, 0xdb, 0xff, 0x1e, 0x79, 0x9c, 0xff, 0x13, 0x7c, 0xcb, 0xff, 0x10, 0x6d, 0xbb, 0xff, 0x34, 0x67, 0x7e, 0xff, 0x58, 0x71, 0x74, 0xff, 0x1c, 0x47, 0x5b, 0xff, 0x8e, 0xa2, 0xa4, 0xff, 0xa9, 0xbe, 0xc0, 0xff, 0x6e, 0x84, 0x89, 0xff, 0x55, 0x67, 0x6e, 0xff, 0x76, 0x8d, 0x8e, 0xff, 0x7b, 0x94, 0x97, 0xff, 0x5c, 0x7c, 0x85, 0xff, 0x8d, 0xaa, 0xaf, 0xff, 0x8c, 0xb3, 0xb6, 0xff, 0xa4, 0xbe, 0xc1, 0xff, 0xac, 0xc5, 0xc5, 0xff, 0xa5, 0xbd, 0xbe, 0xff, 0x70, 0x89, 0x8d, 0xff, 0x3e, 0x51, 0x53, 0xff, 0x51, 0x62, 0x63, 0xff, 0x1a, 0x27, 0x38, 0xff, 0x15, 0x38, 0x4f, 0xff, 0x3f, 0x4f, 0x4c, 0xff, 0x96, 0xaa, 0xa1, 0xff, 0x9f, 0xb3, 0xaa, 0xff,
  0x33, 0x88, 0x9e, 0xff, 0x78, 0xb7, 0xb1, 0xff, 0xb4, 0xdf, 0xde, 0xff, 0x8e, 0xac, 0xb0, 0xff, 0x24, 0x3a, 0x44, 0xff, 0x11, 0x20, 0x2e, 0xff, 0x13, 0x20, 0x26, 0xff, 0x20, 0x31, 0x3b, 0xff, 0x36, 0x49, 0x53, 0xff, 0x6d, 0x82, 0x87, 0xff, 0x9e, 0xbc, 0xbb, 0xff, 0xa1, 0xb0, 0xb4, 0xff, 0xc4, 0xdd, 0xe2, 0xff, 0xd1, 0xed, 0xee, 0xff, 0xcb, 0xe8, 0xe9, 0xff, 0xc3, 0xe4, 0xe5, 0xff, 0xc8, 0xe7, 0xe9, 0xff, 0xb5, 0xdb, 0xe6, 0xff, 0x94, 0xc5, 0xdf, 0xff, 0xad, 0xd3, 0xe8, 0xff, 0xcd, 0xef, 0xf1, 0xff, 0xd4, 0xf1, 0xf5, 0xff, 0xc4, 0xe7, 0xef, 0xff, 0xc5, 0xe1, 0xeb, 0xff, 0xa4, 0xc8, 0xd8, 0xff, 0x4e, 0x7c, 0x97, 0xff, 0x7e, 0x9c, 0xa8, 0xff, 0x5b, 0x75, 0x71, 0xff, 0x78, 0x8a, 0x87, 0xff, 0x77, 0x8c, 0x89, 0xff, 0xb0, 0xc5, 0xbd, 0xff, 0xa9, 0xc1, 0xb7, 0xff,
  0x56, 0x94, 0x93, 0xff, 0xac, 0xd6, 0xd0, 0xff, 0xc9, 0xea, 0xeb, 0xff, 0xc1, 0xdf, 0xe1, 0xff, 0x9a, 0xc5, 0xc5, 0xff, 0x5e, 0x87, 0x86, 0xff, 0x53, 0x76, 0x69, 0xff, 0x8b, 0xab, 0xa4, 0xff, 0xb0, 0xce, 0xcf, 0xff, 0xc8, 0xe2, 0xe4, 0xff, 0xd4, 0xee, 0xed, 0xff, 0xd7, 0xf1, 0xf1, 0xff, 0xd9, 0xf5, 0xf6, 0xff, 0xd9, 0xf7, 0xfa, 0xff, 0xd7, 0xf8, 0xf9, 0xff, 0xdc, 0xf9, 0xf7, 0xff, 0xe3, 0xf6, 0xf9, 0xff, 0xb8, 0xf0, 0xf5, 0xff, 0xc0, 0xf6, 0xf9, 0xff, 0xc3, 0xe9, 0xf3, 0xff, 0xe4, 0xf9, 0xf8, 0xff, 0xd8, 0xf5, 0xf8, 0xff, 0x9b, 0xcd, 0xe7, 0xff, 0x76, 0xc2, 0xe5, 0xff, 0x86, 0xc3, 0xe9, 0xff, 0x86, 0xc6, 0xec, 0xff, 0x7c, 0xb5, 0xdd, 0xff, 0x67, 0x97, 0xae, 0xff, 0x77, 0x9d, 0xa6, 0xff, 0x72, 0x91, 0x8e, 0xff, 0xbd, 0xd0, 0xc7, 0xff, 0xc3, 0xd8, 0xd2, 0xff,
  0x79, 0xaa, 0x9f, 0xff, 0xbf, 0xe3, 0xdd, 0xff, 0xdb, 0xf3, 0xf5, 0xff, 0xd7, 0xf0, 0xf1, 0xff, 0xbb, 0xe6, 0xe3, 0xff, 0x87, 0xb6, 0xb8, 0xff, 0x7c, 0xa7, 0x94, 0xff, 0xb0, 0xd2, 0xc7, 0xff, 0xd2, 0xed, 0xef, 0xff, 0xdb, 0xf5, 0xf7, 0xff, 0xdd, 0xf8, 0xf9, 0xff, 0xe1, 0xf6, 0xf9, 0xff, 0xda, 0xf6, 0xf9, 0xff, 0xdb, 0xf7, 0xfa, 0xff, 0xde, 0xf9, 0xfa, 0xff, 0xe5, 0xf9, 0xf9, 0xff, 0xdb, 0xe8, 0xf6, 0xff, 0xb9, 0xdc, 0xf0, 0xff, 0xb0, 0xda, 0xef, 0xff, 0xc4, 0xe0, 0xf3, 0xff, 0xe4, 0xf1, 0xf7, 0xff, 0xb6, 0xe1, 0xef, 0xff, 0x9f, 0xd5, 0xf1, 0xff, 0x76, 0xbd, 0xde, 0xff, 0x58, 0x9d, 0xc5, 0xff, 0x5b, 0x91, 0xc2, 0xff, 0x8b, 0xc2, 0xeb, 0xff, 0xa6, 0xd4, 0xf6, 0xff, 0x7d, 0xb6, 0xe1, 0xff, 0x64, 0x9b, 0xbd, 0xff, 0xa8, 0xc1, 0xc8, 0xff, 0xab, 0xbc, 0xb9, 0xff,
  0x88, 0xbc, 0xad, 0xff, 0xc6, 0xe9, 0xe4, 0xff, 0xde, 0xf5, 0xf6, 0xff, 0xd7, 0xf1, 0xf1, 0xff, 0xba, 0xe5, 0xe2, 0xff, 0x8b, 0xb7, 0xba, 0xff, 0x87, 0xb2, 0xa0, 0xff, 0xae, 0xcf, 0xc6, 0xff, 0xd9, 0xf2, 0xf1, 0xff, 0xdc, 0xf5, 0xf6, 0xff, 0xdc, 0xf7, 0xf9, 0xff, 0xe2, 0xf5, 0xf9, 0xff, 0xda, 0xf7, 0xf9, 0xff, 0xda, 0xf7, 0xfa, 0xff, 0xdf, 0xf9, 0xfa, 0xff, 0xd8, 0xea, 0xf4, 0xff, 0xa4, 0xab, 0xe3, 0xff, 0xb3, 0xc5, 0xf2, 0xff, 0xb3, 0xcf, 0xf5, 0xff, 0xaa, 0xbb, 0xeb, 0xff, 0xb8, 0xbe, 0xe7, 0xff, 0xe1, 0xf6, 0xfa, 0xff, 0xa7, 0xdf, 0xef, 0xff, 0x82, 0xbf, 0xdc, 0xff, 0x7f, 0xb7, 0xd8, 0xff, 0x9d, 0xd0, 0xf4, 0xff, 0x9f, 0xd3, 0xf9, 0xff, 0x82, 0xbf, 0xec, 0xff, 0x82, 0xbc, 0xec, 0xff, 0x8e, 0xc0, 0xee, 0xff, 0x80, 0xb2, 0xdd, 0xff, 0x87, 0xab, 0xc0, 0xff,
  0x91, 0xc3, 0xb3, 0xff, 0xc4, 0xe9, 0xe4, 0xff, 0xd9, 0xf3, 0xf3, 0xff, 0xd4, 0xef, 0xef, 0xff, 0xb6, 0xe1, 0xde, 0xff, 0x8b, 0xb8, 0xb9, 0xff, 0x8c, 0xb7, 0xa6, 0xff, 0xaf, 0xd1, 0xc7, 0xff, 0xce, 0xe9, 0xe6, 0xff, 0xd7, 0xf1, 0xf2, 0xff, 0xd9, 0xf3, 0xf5, 0xff, 0xe7, 0xf7, 0xfa, 0xff, 0xe2, 0xf8, 0xfa, 0xff, 0xdf, 0xf9, 0xfb, 0xff, 0xe1, 0xf9, 0xf9, 0xff, 0xc5, 0xde, 0xec, 0xff, 0x78, 0x89, 0xd6, 0xff, 0x93, 0x9e, 0xe4, 0xff, 0xa0, 0xbc, 0xeb, 0xff, 0x89, 0x9a, 0xde, 0xff, 0x8f, 0x96, 0xdb, 0xff, 0xda, 0xeb, 0xf3, 0xff, 0xbc, 0xe5, 0xf0, 0xff, 0x95, 0xcf, 0xee, 0xff, 0x86, 0xbe, 0xdd, 0xff, 0x88, 0xbf, 0xe5, 0xff, 0xa2, 0xd1, 0xf5, 0xff, 0x9a, 0xca, 0xf3, 0xff, 0x91, 0xbc, 0xef, 0xff, 0x91, 0xba, 0xeb, 0xff, 0x92, 0xb9, 0xea, 0xff, 0x8a, 0xba, 0xe6, 0xff,
  0x98, 0xc7, 0xba, 0xff, 0xc1, 0xe7, 0xe3, 0xff, 0xda, 0xf2, 0xf2, 0xff, 0xcc, 0xea, 0xe8, 0xff, 0xb3, 0xe0, 0xd9, 0xff, 0x81, 0xaf, 0xaa, 0xff, 0x8c, 0xb6, 0xa5, 0xff, 0xb9, 0xd7, 0xce, 0xff, 0xd1, 0xeb, 0xe7, 0xff, 0xe1, 0xf7, 0xf8, 0xff, 0xe4, 0xf8, 0xfa, 0xff, 0xea, 0xf6, 0xfa, 0xff, 0xe4, 0xf7, 0xfa, 0xff, 0xe1, 0xf9, 0xfa, 0xff, 0xe2, 0xfa, 0xfa, 0xff, 0xe8, 0xf9, 0xfa, 0xff, 0xb9, 0xbf, 0xe7, 0xff, 0x8a, 0x90, 0xdd, 0xff, 0xa0, 0xbe, 0xed, 0xff, 0x9c, 0xab, 0xe5, 0xff, 0xc1, 0xd5, 0xec, 0xff, 0xe5, 0xf9, 0xf9, 0xff, 0xde, 0xf9, 0xf7, 0xff, 0x90, 0xc7, 0xe4, 0xff, 0x62, 0x92, 0xc8, 0xff, 0x65, 0x9c, 0xcf, 0xff, 0x86, 0xc8, 0xf3, 0xff, 0x73, 0xb8, 0xe8, 0xff, 0x8d, 0xbc, 0xf0, 0xff, 0x95, 0xc7, 0xf4, 0xff, 0x77, 0x9f, 0xd5, 0xff, 0x93, 0xbd, 0xeb, 0xff
        }, ColorDepth.ColorDepth32);
        #endregion
        protected override void DrawImplementation()
        {
            Kernel.PrintDebug("Owo print the el pueblob");
            Environment.DrawImage(ElPuebloBitmap, Location);
        }

        protected override Rectangle GetRenderBounds() => new Rectangle(SystemPointLocation, new Size((int)ElPuebloBitmap.Width, (int)ElPuebloBitmap.Height));
        public ElPuebloDrawing(UIEnvironment env) : base(env)
        {
        }

        public ElPuebloDrawing(UIEnvironment env, Point location, Size size = default) : base(env, location, size)
        {
        }
    }
}