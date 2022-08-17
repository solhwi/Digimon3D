using System;
using System.Collections.Generic;

namespace Common
{
    class CommonVector3D
    {
        float x, y, z;
    }

    class CommonBounds
    {
        CommonVector3D Center;
        CommonVector3D Extent;
    }

    class MapData
    {
        public int objId;

        public CommonVector3D worldPos;

        public ENUM_LAYER_TYPE layerType;
        public ENUM_TAG_TYPE tagType;

        public ENUM_COLLIDER_TYPE colliderType;

        public CommonBounds bounds;
    }
}
