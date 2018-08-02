using System;
using Utilities;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Windows.Input;
using WindowsInput.Native;


namespace TotemSmash_{

    public partial class Form1 : Form{

        WindowsInput.InputSimulator SimKeypress = new WindowsInput.InputSimulator();
        globalKeyboardHook gkh = new globalKeyboardHook();
        List<KeyValuePair<string, Macro>> MacroList = new List<KeyValuePair<string, Macro>>();
        //List<Macro> MacroList = new List<Macro>();
       // List<string> MacroList = new List<string>();
        public bool record = false;
        Stopwatch stopwatch = new Stopwatch();
        List<Keys> AllKeys = new List<Keys> {Keys.LControlKey, Keys.LShiftKey, Keys.A, Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, Keys.Z, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9 };
        //List<string>

        public Form1(){ 
            
            InitializeComponent();
            gkh.KeyDown += new KeyEventHandler(gkh_KeyDown);
            gkh.KeyUp += new KeyEventHandler(gkh_KeyUp);           
            gkh.HookedKeys.AddRange(AllKeys);
            
        }

        void gkh_KeyUp(object sender, KeyEventArgs e){
           
        }

        void gkh_KeyDown(object sender, KeyEventArgs e){

            try {                

                txtOut.AppendText(e.KeyCode.ToString());

                //If recording collect keyboard inputs and record time between inputs
                //If not recording check out list of saved keybinds and perform any actions necessary             
                if (record) {

                    Macro macro = new Macro();
                    MacroList.Add(new KeyValuePair<string, Macro>(txtMacroName.Text, macro));

                    MacroList[0].KeySimulation.Add(new KeyValuePair<long, string>(stopwatch.ElapsedMilliseconds, e.KeyCode.ToString()));

                    e.Handled = true;
                }
                else if (!record) {
                    
                    try {
                        foreach(string macro in MacroList) {

                            if (e.KeyCode.ToString() == macro) {                                    

                                //TODO: PRESS RECORDED KEY COMBO                                        
                                //VirtualKeyCode keyCode = VirtualKeyCode.VK_C;
                                //SimKeypress.Keyboard.KeyPress(keyCode);
                                    
                            }                           
                        }                       
                    }
                    catch (Exception exc) {

                    }


                    e.Handled = true;
                }
            }
            catch (Exception exc) { }
        } 

        private void btnRecord_Click(object sender, EventArgs e){

            stopwatch.Start();
            record = true;
        }

        private void btnStopRecord_Click(object sender, EventArgs e){

            stopwatch.Stop();
            record = false;
        }
    }
}
