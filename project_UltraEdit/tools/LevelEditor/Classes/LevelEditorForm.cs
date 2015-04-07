/*  $Id: LevelEditorForm.cs,v 1.1 2006/11/17 06:47:40 jenetic.bytemare Exp $
 *  =================================================================================
 *  The 3dsmax-loader.
 */

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Classes
{
    public class LevelEditorForm : Form
    {
        public  static  LevelEditorForm     levelEditorForm         = null;

        public  static  bool                firstOnPaintSkipped     = false;
        public  static  Pen                 blackPen                = new Pen( Color.Black, 3 );
        public  static  Pen                 whitePen                = new Pen( Color.White, 3 );
        public  static  SolidBrush          blackBrush              = new SolidBrush( Color.Black );
        public  static  SolidBrush          whiteBrush              = new SolidBrush( Color.White );
        public  static  SolidBrush          redBrush                = new SolidBrush( Color.Red );
        public  static  SolidBrush          grayBrush               = new SolidBrush( Color.Gray );
        public  static  Button              buttonNew               = null;
        public  static  Button              buttonLoad              = null;
        public  static  Button              buttonSave              = null;
        public  static  Button              buttonExit              = null;
        public  static  Label               labelX                  = null;
        public  static  Label               labelY                  = null;
        public  static  Label               labelZ                  = null;
        public  static  Label               labelWidth              = null;
        public  static  Label               labelHeight             = null;
        public  static  Label               labelDepth              = null;
        public  static  Label               labelTextureID          = null;
        public  static  Label               labelTilingX            = null;
        public  static  Label               labelTilingY            = null;
        public  static  Label               labelCurrentMesh        = null;
        public  static  TextBox             boxX                    = null;
        public  static  TextBox             boxY                    = null;
        public  static  TextBox             boxZ                    = null;
        public  static  TextBox             boxWidth                = null;
        public  static  TextBox             boxHeight               = null;
        public  static  TextBox             boxDepth                = null;
        public  static  TextBox             boxTextureID            = null;
        public  static  TextBox             boxTilingX              = null;
        public  static  TextBox             boxTilingY              = null;
        public  static  TextBox             boxCurrentMesh          = null;
        public  static  VScrollBar          vScrollBar              = null;
        public  static  HScrollBar          hScrollBar              = null;

        public static void init()
        {
            //init components
            buttonNew                       = new LevelEditorButton( "Neu",         new Point( 10,  10 ),  null );
            buttonLoad                      = new LevelEditorButton( "Laden",       new Point( 10,  50 ),  null );
            buttonSave                      = new LevelEditorButton( "Speichern",   new Point( 100, 10 ),  null );
            buttonExit                      = new LevelEditorButton( "Beenden",     new Point( 100, 50 ),  new EventHandler( onClickButtonExit ) );

            labelX                          = new LevelEditorLabel( "x:",            new Point( 70, 100 ), ContentAlignment.MiddleRight, Color.White, Color.Gray, new Size(  40, 13 ) );
            labelY                          = new LevelEditorLabel( "y:",            new Point( 70, 120 ), ContentAlignment.MiddleRight, Color.White, Color.Gray, new Size(  40, 13 ) );
            labelZ                          = new LevelEditorLabel( "z:",            new Point( 70, 140 ), ContentAlignment.MiddleRight, Color.White, Color.Gray, new Size(  40, 13 ) );
            labelWidth                      = new LevelEditorLabel( "width:",        new Point( 70, 160 ), ContentAlignment.MiddleRight, Color.White, Color.Gray, new Size(  40, 13 ) );
            labelHeight                     = new LevelEditorLabel( "height:",       new Point( 70, 180 ), ContentAlignment.MiddleRight, Color.White, Color.Gray, new Size(  40, 13 ) );
            labelDepth                      = new LevelEditorLabel( "depth:",        new Point( 70, 200 ), ContentAlignment.MiddleRight, Color.White, Color.Gray, new Size(  40, 13 ) );
            labelTextureID                  = new LevelEditorLabel( "textureID:",    new Point( 70, 220 ), ContentAlignment.MiddleRight, Color.White, Color.Gray, new Size(  40, 13 ) );
            labelTilingX                    = new LevelEditorLabel( "tilingX:",      new Point( 70, 240 ), ContentAlignment.MiddleRight, Color.White, Color.Gray, new Size(  40, 13 ) );
            labelTilingY                    = new LevelEditorLabel( "tilingY:",      new Point( 70, 260 ), ContentAlignment.MiddleRight, Color.White, Color.Gray, new Size(  40, 13 ) );
            labelCurrentMesh                = new LevelEditorLabel( "Current Mesh:", new Point( 20, 300 ), ContentAlignment.MiddleLeft,  Color.White, Color.Gray, new Size(  80, 13 ) );

            boxX                            = new LevelEditorTextBox( new Point( 120, 100 ), BorderStyle.None, new Size( 50, 13 ) );
            boxY                            = new LevelEditorTextBox( new Point( 120, 120 ), BorderStyle.None, new Size( 50, 13 ) );
            boxZ                            = new LevelEditorTextBox( new Point( 120, 140 ), BorderStyle.None, new Size( 50, 13 ) );
            boxWidth                        = new LevelEditorTextBox( new Point( 120, 160 ), BorderStyle.None, new Size( 50, 13 ) );
            boxHeight                       = new LevelEditorTextBox( new Point( 120, 180 ), BorderStyle.None, new Size( 50, 13 ) );
            boxDepth                        = new LevelEditorTextBox( new Point( 120, 200 ), BorderStyle.None, new Size( 50, 13 ) );
            boxTextureID                    = new LevelEditorTextBox( new Point( 120, 220 ), BorderStyle.None, new Size( 50, 13 ) );
            boxTilingX                      = new LevelEditorTextBox( new Point( 120, 240 ), BorderStyle.None, new Size( 50, 13 ) );
            boxTilingY                      = new LevelEditorTextBox( new Point( 120, 260 ), BorderStyle.None, new Size( 50, 13 ) );
            boxCurrentMesh                  = new LevelEditorTextBox( new Point( 120, 300 ), BorderStyle.None, new Size( 50, 13 ) );

            vScrollBar                      = new VScrollBar();
            hScrollBar                      = new HScrollBar();

            vScrollBar.Size                 = new Size( 804, 748 );
            hScrollBar.Size                 = new Size( 804, 748 );

            vScrollBar.Location             = new Point( 804, 0  );
            hScrollBar.Location             = new Point( 200, 748 );



            //init form
            levelEditorForm                 = new LevelEditorForm();
            levelEditorForm.Text            = "Amy's Abduction Level Editor";
            levelEditorForm.Icon            = new Icon(     "images/app.ico"    );
            levelEditorForm.ClientSize      = new Size(     1024,   768         );
            levelEditorForm.Location        = new Point(    50,      50           );
            levelEditorForm.StartPosition   = FormStartPosition.Manual;
            levelEditorForm.SetStyle ( ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true );
            levelEditorForm.FormBorderStyle = FormBorderStyle.None;

            //add components to form
            levelEditorForm.Controls.Add( buttonNew         );
            levelEditorForm.Controls.Add( buttonLoad        );
            levelEditorForm.Controls.Add( buttonSave        );
            levelEditorForm.Controls.Add( buttonExit        );
            levelEditorForm.Controls.Add( boxX              );
            levelEditorForm.Controls.Add( boxY              );
            levelEditorForm.Controls.Add( boxZ              );
            levelEditorForm.Controls.Add( boxWidth          );
            levelEditorForm.Controls.Add( boxHeight         );
            levelEditorForm.Controls.Add( boxDepth          );
            levelEditorForm.Controls.Add( boxTextureID      );
            levelEditorForm.Controls.Add( boxTilingX        );
            levelEditorForm.Controls.Add( boxTilingY        );
            levelEditorForm.Controls.Add( boxCurrentMesh    );
            levelEditorForm.Controls.Add( labelX            );
            levelEditorForm.Controls.Add( labelY            );
            levelEditorForm.Controls.Add( labelZ            );
            levelEditorForm.Controls.Add( labelWidth        );
            levelEditorForm.Controls.Add( labelHeight       );
            levelEditorForm.Controls.Add( labelDepth        );
            levelEditorForm.Controls.Add( labelTextureID    );
            levelEditorForm.Controls.Add( labelTilingX      );
            levelEditorForm.Controls.Add( labelTilingY      );
            levelEditorForm.Controls.Add( labelCurrentMesh  );
            levelEditorForm.Controls.Add( LevelEditorPanel.levelEditorPanel );
            levelEditorForm.Controls.Add( vScrollBar        );
            levelEditorForm.Controls.Add( hScrollBar        );

            //show form
            levelEditorForm.Show();

        } //endmethod

        protected override void OnPaint ( PaintEventArgs e )
        {
            if ( firstOnPaintSkipped )
            {
                base.OnPaint( e );
                onPaint( e.Graphics );
            }
            else
            {
                firstOnPaintSkipped = true;
            } //endif
        } //endmethod

        private void onPaint( Graphics g )
        {
            //clear screen
            g.FillRectangle( grayBrush,    0.0f, 0.0f, levelEditorForm.Width, levelEditorForm.Height );

        } //endmethod

        private static void onClickButtonExit( object sender, EventArgs e )
        {
            Application.Exit();

        } //endmethod

    } //endclass
} //endnamespace

/*
 *  $Log: LevelEditorForm.cs,v $
 *  Revision 1.1  2006/11/17 06:47:40  jenetic.bytemare
 *  safe
 *
 *  Revision 1.4  2006/10/16 14:18:57  Mr. jenetic.bytemare
 *  advanced 3dsmax-importer
 *
 *  Revision 1.3  2006/10/16 11:35:13  Mr. jenetic.bytemare
 *  editor makings
 *
 *  Revision 1.2  2006/10/12 14:12:10  Mr. jenetic.bytemare
 *  implemented directX sound-system
 *  levelEditor in progress
 *
 *  Revision 1.1  2006/10/31 03:16:10  Mr. jenetic.bytemare
 *  level-editor in progress
 *
 */
