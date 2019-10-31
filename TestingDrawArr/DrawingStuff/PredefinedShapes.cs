using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingDrawArr.DrawingStuff
{
    public static class PredefinedShapes
    {
        // ASCII - Sword
        static readonly List<string> lSword = new List<string>()
        {
            "    .^.    ",
            "    |Y|    ",
            "    |||    ",
            "    |||    ",
            "    |||    ",
            "    |||    ",
            "    |||    ",
            "    |||    ",
            "    |||    ",
            "    |||    ",
            "    |||    ",
            "    |_|    ",
            "<>==[V!==<>",
            "    }X{    ",
            "    }X{    ",
            "    (o)    ",
        };
        static readonly List<string> lSword_Colors = new List<string>()
        {
            "    ooo    ",
            "    oCo    ",
            "    oCo    ",
            "    oCo    ",
            "    oCo    ",
            "    oCo    ",
            "    oCo    ",
            "    oCo    ",
            "    oCo    ",
            "    oCo    ",
            "    oCo    ",
            "    ooo    ",
            "CCooCCCooCC",
            "    YYY    ",
            "    YYY    ",
            "    oro    ",
        };

        // ASCII - Axe
        static readonly List<string> lAxe = new List<string>()
        {
            "      ___              ",
            "   __/:_:\\___________  ",
            "  /88{|88|}888888888`\\ ",
            " /888{|88|}888888888`||",
            "{88__||88||88888888`// ",
            "|/    \\__/-_888888`//  ",
            "      |::|   }888`//   ",
            "      |::|   \\88`/     ",
            "      |::/    \\//      ",
            "      |X|              ",
            "      |X|              ",
            "      |X|              ",
            "      |X|              ",
            "      |X|              ",
            "      |_|              ",
            "      {o}              ",
            "     <{_}>             ",
        };
        static readonly List<string> lAxe_Colors = new List<string>()
        {
            "      ooo              ",
            "   oooCoCoooooooooooo  ",
            "  o  Oo  oO         Co ",
            " o   Oo  oO         Coo",
            "o  ooOo  oO        Coo ",
            "oo    ooooOo      Coo  ",
            "      OCCO   o   Coo   ",
            "      OCCO   o  Co     ",
            "      OCCO    ooo      ",
            "      YYY              ",
            "      YYY              ",
            "      YYY              ",
            "      YYY              ",
            "      YYY              ",
            "      YYY              ",
            "      CrC              ",
            "     OOOOO             ",
        };

        // ASCII - Hammer
        static readonly List<string> lHammer = new List<string>();
        static readonly List<string> lHammer_Colors = new List<string>();

        // ASCII - Unarmed
        static readonly List<string> lUnarmed = new List<string>();
        static readonly List<string> lUnarmed_Colors = new List<string>();

        // ASCII - Building - 0
        static readonly List<string> lBuilding0 = new List<string>()
        {
            "               _           ",
            "              | |          ",
            "     _________|_|__        ",
            "    {==============}       ",
            "    {||    /\\    ||}       ",
            "   /''''''//\\\\''''''\\      ",
            "  /______/_[]_\\______\\     ",
            " /____| |======| |____\\    ",
            " ||   |X|;;;;;;|X|   ||    ",
            " || []|X|      |X|[] ||    ",
            "{M}   |X|      |X|   {M}   ",
            " V| []|W|      |W|[] |V    ",
            " ||   {_}______{_}   ||    ",
            " []__<{_}>____<{_}>__[]    ",
        };
        static readonly List<string> lBuilding0_Colors = new List<string>()
        {
            "              ooo          ",
            "              O O          ",
            "     YYYYYYYYYOYOYY        ",
            "    YyyyyyyyyyyyyyyY       ",
            "    YyyYYYYyyYYYYyyY       ",
            "   YYY  YYyyyyYY  YYY      ",
            "  YYYYYYOyOWWOyOYYYYYY     ",
            " YYYYYOBOYYYYYYOBOYYYYY    ",
            " OO   ObObbbbbbObO   OO    ",
            " OO WWOBO      OBOWW OO    ",
            "oro WWObO      ObOWW oro   ",
            " oO WWObO      ObOWW Oo    ",
            " OO   OyOyyyyyyOyO   OO    ",
            " OOYYOOOOOYYYYOOOOOYYOO    ",
        };




        // These are for initializing predefined shapes
        public static int Get_Width(DrawTool.ShapeTypes shapeType)
        {
            switch (shapeType)
            {
                case DrawTool.ShapeTypes.Sword:
                    return lSword[0].Length;

                case DrawTool.ShapeTypes.Axe:
                    return lAxe[0].Length;

                case DrawTool.ShapeTypes.Hammer:
                    return lHammer[0].Length;

                case DrawTool.ShapeTypes.Unarmed:
                    return lUnarmed[0].Length;

                case DrawTool.ShapeTypes.Building_0:
                    return lBuilding0[0].Length;

                default:
                    return -1;
            }
        }
        public static int Get_Height(DrawTool.ShapeTypes shapeType)
        {
            switch (shapeType)
            {
                case DrawTool.ShapeTypes.Sword:
                    return lSword.Count;

                case DrawTool.ShapeTypes.Axe:
                    return lAxe.Count;

                case DrawTool.ShapeTypes.Hammer:
                    return lHammer.Count;

                case DrawTool.ShapeTypes.Unarmed:
                    return lUnarmed.Count;

                case DrawTool.ShapeTypes.Building_0:
                    return lBuilding0.Count;

                default:
                    return -1;
            }
        }
        public static List<string> Get_ListStrings(DrawTool.ShapeTypes shapeType)
        {
            switch (shapeType)
            {
                case DrawTool.ShapeTypes.Sword:
                    return lSword;

                case DrawTool.ShapeTypes.Axe:
                    return lAxe;

                case DrawTool.ShapeTypes.Hammer:
                    return lHammer;

                case DrawTool.ShapeTypes.Unarmed:
                    return lUnarmed;

                case DrawTool.ShapeTypes.Building_0:
                    return lBuilding0;

                default:
                    return null;
            }
        }
        public static List<string> Get_ListColors(DrawTool.ShapeTypes shapeType)
        {
            switch (shapeType)
            {
                case DrawTool.ShapeTypes.Sword:
                    return lSword_Colors;

                case DrawTool.ShapeTypes.Axe:
                    return lAxe_Colors;

                case DrawTool.ShapeTypes.Hammer:
                    return lHammer_Colors;

                case DrawTool.ShapeTypes.Unarmed:
                    return lUnarmed_Colors;

                case DrawTool.ShapeTypes.Building_0:
                    return lBuilding0_Colors;

                default:
                    return null;
            }
        }
    }

}
