using PortScanTool.Model;
using System;
using System.Net;
using System.Windows.Forms;

namespace PortScanTool
{
    partial class PortScan
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.run = new System.Windows.Forms.Button();
            this.ProccessText = new System.Windows.Forms.Label();
            this.ProccessValue = new System.Windows.Forms.Label();
            this.passedItems = new System.Windows.Forms.ListBox();
            this.failedItems = new System.Windows.Forms.ListBox();
            this.passedItemsText = new System.Windows.Forms.Label();
            this.failedItemsText = new System.Windows.Forms.Label();
            this.threadTrackBar = new System.Windows.Forms.TrackBar();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.terminate = new System.Windows.Forms.Button();
            this.StartedIp = new System.Windows.Forms.MaskedTextBox();
            this.EndIp = new System.Windows.Forms.MaskedTextBox();
            this.IpRangeText = new System.Windows.Forms.Label();
            this.ClearItems = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.threadTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(48, 138);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(75, 23);
            this.run.TabIndex = 0;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.Run_Click);
            // 
            // ProccessText
            // 
            this.ProccessText.AutoSize = true;
            this.ProccessText.Location = new System.Drawing.Point(57, 354);
            this.ProccessText.Name = "ProccessText";
            this.ProccessText.Size = new System.Drawing.Size(56, 15);
            this.ProccessText.TabIndex = 1;
            this.ProccessText.Text = "Proccess:";
            // 
            // ProccessValue
            // 
            this.ProccessValue.AutoSize = true;
            this.ProccessValue.Location = new System.Drawing.Point(170, 354);
            this.ProccessValue.Name = "ProccessValue";
            this.ProccessValue.Size = new System.Drawing.Size(16, 15);
            this.ProccessValue.TabIndex = 2;
            this.ProccessValue.Text = "...";
            // 
            // passedItems
            // 
            this.passedItems.FormattingEnabled = true;
            this.passedItems.ItemHeight = 15;
            this.passedItems.Location = new System.Drawing.Point(361, 80);
            this.passedItems.Name = "passedItems";
            this.passedItems.Size = new System.Drawing.Size(179, 289);
            this.passedItems.TabIndex = 3;
            // 
            // failedItems
            // 
            this.failedItems.FormattingEnabled = true;
            this.failedItems.ItemHeight = 15;
            this.failedItems.Location = new System.Drawing.Point(546, 80);
            this.failedItems.Name = "failedItems";
            this.failedItems.Size = new System.Drawing.Size(179, 289);
            this.failedItems.TabIndex = 3;
            // 
            // passedItemsText
            // 
            this.passedItemsText.AutoSize = true;
            this.passedItemsText.Location = new System.Drawing.Point(361, 48);
            this.passedItemsText.Name = "passedItemsText";
            this.passedItemsText.Size = new System.Drawing.Size(43, 15);
            this.passedItemsText.TabIndex = 4;
            this.passedItemsText.Text = "Passed";
            // 
            // failedItemsText
            // 
            this.failedItemsText.AutoSize = true;
            this.failedItemsText.Location = new System.Drawing.Point(546, 48);
            this.failedItemsText.Name = "failedItemsText";
            this.failedItemsText.Size = new System.Drawing.Size(38, 15);
            this.failedItemsText.TabIndex = 5;
            this.failedItemsText.Text = "Failed";
            // 
            // threadTrackBar
            // 
            this.threadTrackBar.LargeChange = 3;
            this.threadTrackBar.Location = new System.Drawing.Point(57, 240);
            this.threadTrackBar.Maximum = 30;
            this.threadTrackBar.Minimum = 1;
            this.threadTrackBar.Name = "threadTrackBar";
            this.threadTrackBar.Size = new System.Drawing.Size(224, 45);
            this.threadTrackBar.TabIndex = 6;
            this.threadTrackBar.TickFrequency = 5;
            this.threadTrackBar.Value = 4;
            this.threadTrackBar.Scroll += new System.EventHandler(this.ThreadTrackBar_Scroll);
            this.threadTrackBar.MouseLeave += new System.EventHandler(this.ThreadTrackBar_MouseLeave);
            // 
            // terminate
            // 
            this.terminate.Location = new System.Drawing.Point(138, 138);
            this.terminate.Name = "terminate";
            this.terminate.Size = new System.Drawing.Size(75, 23);
            this.terminate.TabIndex = 7;
            this.terminate.Text = "Termiante";
            this.terminate.UseVisualStyleBackColor = true;
            this.terminate.Click += new System.EventHandler(this.Terminate_Click);
            // 
            // StartedIp
            // 
            this.StartedIp.Location = new System.Drawing.Point(112, 80);
            this.StartedIp.Mask = "###,###,###,###";
            this.StartedIp.Name = "StartedIp";
            this.StartedIp.PromptChar = ' ';
            this.StartedIp.ResetOnSpace = false;
            this.StartedIp.Size = new System.Drawing.Size(84, 23);
            this.StartedIp.TabIndex = 8;
            // 
            // EndIp
            // 
            this.EndIp.Location = new System.Drawing.Point(202, 80);
            this.EndIp.Mask = "###,###,###,###";
            this.EndIp.Name = "EndIp";
            this.EndIp.PromptChar = ' ';
            this.EndIp.ResetOnSpace = false;
            this.EndIp.Size = new System.Drawing.Size(84, 23);
            this.EndIp.TabIndex = 8;
            // 
            // IpRangeText
            // 
            this.IpRangeText.AutoSize = true;
            this.IpRangeText.Location = new System.Drawing.Point(48, 83);
            this.IpRangeText.Name = "IpRangeText";
            this.IpRangeText.Size = new System.Drawing.Size(53, 15);
            this.IpRangeText.TabIndex = 9;
            this.IpRangeText.Text = "Ip Range";
            // 
            // ClearItems
            // 
            this.ClearItems.Location = new System.Drawing.Point(230, 138);
            this.ClearItems.Name = "ClearItems";
            this.ClearItems.Size = new System.Drawing.Size(75, 23);
            this.ClearItems.TabIndex = 10;
            this.ClearItems.Text = "Clear Items";
            this.ClearItems.UseVisualStyleBackColor = true;
            this.ClearItems.Click += new System.EventHandler(this.ClearItems_Click);
            // 
            // PortScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.terminate);
            this.Controls.Add(this.run);
            this.Controls.Add(this.ClearItems);
            this.Controls.Add(this.EndIp);
            this.Controls.Add(this.IpRangeText);
            this.Controls.Add(this.StartedIp);
            this.Controls.Add(this.ProccessValue);
            this.Controls.Add(this.failedItems);
            this.Controls.Add(this.ProccessText);
            this.Controls.Add(this.failedItemsText);
            this.Controls.Add(this.passedItemsText);
            this.Controls.Add(this.passedItems);
            this.Controls.Add(this.threadTrackBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "PortScan";
            this.Text = "Port Scan";
            this.Load += new System.EventHandler(this.PortScan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.threadTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Label ProccessText;
        private System.Windows.Forms.Label ProccessValue;
        private System.Windows.Forms.ListBox failedItems;
        private System.Windows.Forms.Label passedItemsText;
        private System.Windows.Forms.Label failedItemsText;
        public System.Windows.Forms.ListBox passedItems;
        private System.Windows.Forms.TrackBar threadTrackBar;
        private ToolTip toolTip1;
        private Button terminate;
        private MaskedTextBox StartedIp;
        private MaskedTextBox EndIp;
        private Label IpRangeText;
        private Button ClearItems;
    }
}

