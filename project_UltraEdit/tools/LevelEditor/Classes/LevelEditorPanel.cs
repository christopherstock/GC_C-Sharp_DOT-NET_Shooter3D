/*  $Id: LevelEditorPanel.cs,v 1.1 2006/11/17 06:47:40 jenetic.bytemare Exp $
 *  =================================================================================
 *  The 3dsmax-loader.
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Classes
{
    public class LevelEditorPanel : Panel
    {
        public  static  LevelEditorPanel    levelEditorPanel        = null;

        public  const   int                 OFFSET_PADDING_LEFT     = 0;
        public  const   int                 OFFSET_PADDING_RIGHT    = 0;
        public  const   int                 OFFSET_PADDING_TOP      = 0;
        public  const   int                 OFFSET_PADDING_BOTTOM   = 0;

        public  const   int                 MAX_LEVEL_WIDTH         = 5000;
        public  const   int                 MAX_LEVEL_HEIGHT        = 5000;

        public  static  int                 scrollX                 = 0;
        public  static  int                 scrollY                 = 0;

        public  static  int                 posY                    = 0;

        public LevelEditorPanel()
        {
            SetStyle ( ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true );

            Size           = new Size( 804, 748 );
            Location       = new Point( 200, 0 );


        } //endconstruct

        public static void init()
        {
            levelEditorPanel = new LevelEditorPanel();

        } //endmethod

        protected override void OnPaint ( PaintEventArgs e )
        {
            if ( LevelEditorForm.firstOnPaintSkipped )
            {
                base.OnPaint( e );
                onPaint( e.Graphics );
            } //endif
        } //endmethod

        public static void onPaint( Graphics g )
        {
            int clipX       = OFFSET_PADDING_LEFT;
            int clipY       = OFFSET_PADDING_TOP;
            int clipWidth   = LevelEditorForm.levelEditorForm.Width - OFFSET_PADDING_LEFT - OFFSET_PADDING_RIGHT;
            int clipHeight  = LevelEditorForm.levelEditorForm.Height - OFFSET_PADDING_TOP - OFFSET_PADDING_BOTTOM;

            //fill pane
            g.SetClip( new Rectangle( clipX, clipY, clipWidth, clipHeight ) );
            g.FillRectangle( LevelEditorForm.whiteBrush, new Rectangle( clipX, clipY, MAX_LEVEL_WIDTH, MAX_LEVEL_HEIGHT ) );

            //draw all meshes
            foreach ( Mesh mesh in Mesh.meshes )
            {
                mesh.draw( g );

            } //endforeach
        } //endmethod
    } //endclass
} //endnamespace


/*
 *  $Log: LevelEditorPanel.cs,v $
 *  Revision 1.1  2006/11/17 06:47:40  jenetic.bytemare
 *  safe
 *
 *  Revision 1.1  2006/10/16 11:35:13  Mr. jenetic.bytemare
 *  editor makings
 *
 *  Revision 1.2  2006/10/12 14:12:09  Mr. jenetic.bytemare
 *  implemented directX sound-system
 *  levelEditor in progress
 *
 *  Revision 1.1  2006/10/31 03:16:10  Mr. jenetic.bytemare
 *  level-editor in progress
 *
 */
    