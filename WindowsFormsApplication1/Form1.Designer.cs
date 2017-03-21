namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.restPage = new System.Windows.Forms.TabPage();
            this.dropdownMethod = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtboxParams = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSubmitRest = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtboxRestResponse = new System.Windows.Forms.TextBox();
            this.txtboxRestRequest = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtboxUrlRest = new System.Windows.Forms.TextBox();
            this.soapPage = new System.Windows.Forms.TabPage();
            this.btnSubmitsoap = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtboxSoapResponse = new System.Windows.Forms.TextBox();
            this.txtboxSoapRequest = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtboxUrlSoap = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.authPage = new System.Windows.Forms.TabPage();
            this.headersPage = new System.Windows.Forms.TabPage();
            this.assertionsPage = new System.Windows.Forms.TabPage();
            this.restPage.SuspendLayout();
            this.soapPage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // restPage
            // 
            this.restPage.BackColor = System.Drawing.Color.LightGray;
            this.restPage.Controls.Add(this.dropdownMethod);
            this.restPage.Controls.Add(this.label8);
            this.restPage.Controls.Add(this.txtboxParams);
            this.restPage.Controls.Add(this.label7);
            this.restPage.Controls.Add(this.btnSubmitRest);
            this.restPage.Controls.Add(this.label3);
            this.restPage.Controls.Add(this.label2);
            this.restPage.Controls.Add(this.txtboxRestResponse);
            this.restPage.Controls.Add(this.txtboxRestRequest);
            this.restPage.Controls.Add(this.label1);
            this.restPage.Controls.Add(this.txtboxUrlRest);
            this.restPage.Location = new System.Drawing.Point(4, 25);
            this.restPage.Name = "restPage";
            this.restPage.Padding = new System.Windows.Forms.Padding(3);
            this.restPage.Size = new System.Drawing.Size(1010, 544);
            this.restPage.TabIndex = 1;
            this.restPage.Text = "REST";
            // 
            // dropdownMethod
            // 
            this.dropdownMethod.FormattingEnabled = true;
            this.dropdownMethod.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
            this.dropdownMethod.Location = new System.Drawing.Point(893, 15);
            this.dropdownMethod.Name = "dropdownMethod";
            this.dropdownMethod.Size = new System.Drawing.Size(89, 24);
            this.dropdownMethod.TabIndex = 10;
            this.dropdownMethod.Click += new System.EventHandler(this.dropdownMethod_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(823, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 17);
            this.label8.TabIndex = 9;
            this.label8.Text = "Method";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtboxParams
            // 
            this.txtboxParams.Location = new System.Drawing.Point(561, 15);
            this.txtboxParams.Multiline = true;
            this.txtboxParams.Name = "txtboxParams";
            this.txtboxParams.Size = new System.Drawing.Size(225, 22);
            this.txtboxParams.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(495, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 7;
            this.label7.Text = "Params:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // btnSubmitRest
            // 
            this.btnSubmitRest.Location = new System.Drawing.Point(393, 505);
            this.btnSubmitRest.Name = "btnSubmitRest";
            this.btnSubmitRest.Size = new System.Drawing.Size(99, 32);
            this.btnSubmitRest.TabIndex = 6;
            this.btnSubmitRest.Text = "Submit";
            this.btnSubmitRest.UseVisualStyleBackColor = true;
            this.btnSubmitRest.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(544, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Response";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Request";
            // 
            // txtboxRestResponse
            // 
            this.txtboxRestResponse.Location = new System.Drawing.Point(519, 75);
            this.txtboxRestResponse.Multiline = true;
            this.txtboxRestResponse.Name = "txtboxRestResponse";
            this.txtboxRestResponse.Size = new System.Drawing.Size(472, 407);
            this.txtboxRestResponse.TabIndex = 3;
            // 
            // txtboxRestRequest
            // 
            this.txtboxRestRequest.Location = new System.Drawing.Point(22, 75);
            this.txtboxRestRequest.Multiline = true;
            this.txtboxRestRequest.Name = "txtboxRestRequest";
            this.txtboxRestRequest.Size = new System.Drawing.Size(455, 406);
            this.txtboxRestRequest.TabIndex = 2;
            this.txtboxRestRequest.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txtboxUrlRest
            // 
            this.txtboxUrlRest.Location = new System.Drawing.Point(74, 17);
            this.txtboxUrlRest.Multiline = true;
            this.txtboxUrlRest.Name = "txtboxUrlRest";
            this.txtboxUrlRest.Size = new System.Drawing.Size(403, 22);
            this.txtboxUrlRest.TabIndex = 0;
            // 
            // soapPage
            // 
            this.soapPage.BackColor = System.Drawing.Color.Gainsboro;
            this.soapPage.Controls.Add(this.btnSubmitsoap);
            this.soapPage.Controls.Add(this.label4);
            this.soapPage.Controls.Add(this.label5);
            this.soapPage.Controls.Add(this.txtboxSoapResponse);
            this.soapPage.Controls.Add(this.txtboxSoapRequest);
            this.soapPage.Controls.Add(this.label6);
            this.soapPage.Controls.Add(this.txtboxUrlSoap);
            this.soapPage.Location = new System.Drawing.Point(4, 25);
            this.soapPage.Name = "soapPage";
            this.soapPage.Padding = new System.Windows.Forms.Padding(3);
            this.soapPage.Size = new System.Drawing.Size(1010, 544);
            this.soapPage.TabIndex = 0;
            this.soapPage.Text = "SOAP";
            // 
            // btnSubmitsoap
            // 
            this.btnSubmitsoap.Location = new System.Drawing.Point(365, 492);
            this.btnSubmitsoap.Name = "btnSubmitsoap";
            this.btnSubmitsoap.Size = new System.Drawing.Size(99, 32);
            this.btnSubmitsoap.TabIndex = 13;
            this.btnSubmitsoap.Text = "Submit";
            this.btnSubmitsoap.UseVisualStyleBackColor = true;
            this.btnSubmitsoap.Click += new System.EventHandler(this.btnSubmitsoap_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(541, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Response";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Request";
            // 
            // txtboxSoapResponse
            // 
            this.txtboxSoapResponse.Location = new System.Drawing.Point(510, 80);
            this.txtboxSoapResponse.Multiline = true;
            this.txtboxSoapResponse.Name = "txtboxSoapResponse";
            this.txtboxSoapResponse.Size = new System.Drawing.Size(481, 407);
            this.txtboxSoapResponse.TabIndex = 10;
            // 
            // txtboxSoapRequest
            // 
            this.txtboxSoapRequest.Location = new System.Drawing.Point(38, 80);
            this.txtboxSoapRequest.Multiline = true;
            this.txtboxSoapRequest.Name = "txtboxSoapRequest";
            this.txtboxSoapRequest.Size = new System.Drawing.Size(451, 406);
            this.txtboxSoapRequest.TabIndex = 9;
            this.txtboxSoapRequest.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "URL:";
            // 
            // txtboxUrlSoap
            // 
            this.txtboxUrlSoap.Location = new System.Drawing.Point(86, 20);
            this.txtboxUrlSoap.Name = "txtboxUrlSoap";
            this.txtboxUrlSoap.Size = new System.Drawing.Size(827, 22);
            this.txtboxUrlSoap.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.soapPage);
            this.tabControl1.Controls.Add(this.restPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1018, 573);
            this.tabControl1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.authPage);
            this.tabControl2.Controls.Add(this.headersPage);
            this.tabControl2.Controls.Add(this.assertionsPage);
            this.tabControl2.Location = new System.Drawing.Point(16, 591);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(1010, 132);
            this.tabControl2.TabIndex = 1;
            // 
            // authPage
            // 
            this.authPage.Location = new System.Drawing.Point(4, 25);
            this.authPage.Name = "authPage";
            this.authPage.Padding = new System.Windows.Forms.Padding(3);
            this.authPage.Size = new System.Drawing.Size(1002, 103);
            this.authPage.TabIndex = 2;
            this.authPage.Text = "Authentication";
            this.authPage.UseVisualStyleBackColor = true;
            // 
            // headersPage
            // 
            this.headersPage.Location = new System.Drawing.Point(4, 25);
            this.headersPage.Name = "headersPage";
            this.headersPage.Padding = new System.Windows.Forms.Padding(3);
            this.headersPage.Size = new System.Drawing.Size(1002, 103);
            this.headersPage.TabIndex = 0;
            this.headersPage.Text = "Headers";
            this.headersPage.UseVisualStyleBackColor = true;
            // 
            // assertionsPage
            // 
            this.assertionsPage.Location = new System.Drawing.Point(4, 25);
            this.assertionsPage.Name = "assertionsPage";
            this.assertionsPage.Padding = new System.Windows.Forms.Padding(3);
            this.assertionsPage.Size = new System.Drawing.Size(1002, 103);
            this.assertionsPage.TabIndex = 1;
            this.assertionsPage.Text = "Assertions";
            this.assertionsPage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1042, 735);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.restPage.ResumeLayout(false);
            this.restPage.PerformLayout();
            this.soapPage.ResumeLayout(false);
            this.soapPage.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage restPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtboxUrlRest;
        private System.Windows.Forms.TabPage soapPage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txtboxRestResponse;
        private System.Windows.Forms.TextBox txtboxRestRequest;
        private System.Windows.Forms.Button btnSubmitRest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmitsoap;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtboxSoapResponse;
        private System.Windows.Forms.TextBox txtboxSoapRequest;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtboxUrlSoap;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage headersPage;
        private System.Windows.Forms.TabPage assertionsPage;
        private System.Windows.Forms.TabPage authPage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox dropdownMethod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtboxParams;
    }
}

