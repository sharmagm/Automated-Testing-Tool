namespace XMLGradingAssignment
{
    partial class GradingTool
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.AddQuestionBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.quesTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.addAnotherQuesBtn = new System.Windows.Forms.Button();
            this.generateTestXMLBtn = new System.Windows.Forms.Button();
            this.endTestBtn = new System.Windows.Forms.Button();
            this.textTypeAnswerTxt = new System.Windows.Forms.TextBox();
            this.txtTypeAnswerLbl = new System.Windows.Forms.Label();
            this.essayAnsTxt = new System.Windows.Forms.TextBox();
            this.noOfKeywordsTxt = new System.Windows.Forms.TextBox();
            this.noOfWordsLbl = new System.Windows.Forms.Label();
            this.essayKeywordsLbl = new System.Windows.Forms.Label();
            this.essayInstructionLbl = new System.Windows.Forms.Label();
            this.uploadXMLBtn = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.essayAnswerRexponseTxt = new System.Windows.Forms.TextBox();
            this.nextQuesBtn = new System.Windows.Forms.Button();
            this.nextQuesLbl = new System.Windows.Forms.Label();
            this.submitTestBtn = new System.Windows.Forms.Button();
            this.textBox_info = new System.Windows.Forms.TextBox();
            this.label_questype = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(341, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome to Test Creating and Grading Tool";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(64, 91);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Create a test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(139, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Attempt a test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddQuestionBtn
            // 
            this.AddQuestionBtn.Location = new System.Drawing.Point(64, 180);
            this.AddQuestionBtn.Name = "AddQuestionBtn";
            this.AddQuestionBtn.Size = new System.Drawing.Size(139, 23);
            this.AddQuestionBtn.TabIndex = 3;
            this.AddQuestionBtn.Text = "Add a question";
            this.AddQuestionBtn.UseVisualStyleBackColor = true;
            this.AddQuestionBtn.Visible = false;
            this.AddQuestionBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Text Question",
            "Multiple Choice Question",
            "Essay Question"});
            this.comboBox1.Location = new System.Drawing.Point(64, 225);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(238, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Visible = false;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // quesTxt
            // 
            this.quesTxt.Location = new System.Drawing.Point(125, 266);
            this.quesTxt.Name = "quesTxt";
            this.quesTxt.Size = new System.Drawing.Size(690, 20);
            this.quesTxt.TabIndex = 5;
            this.quesTxt.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Question";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(64, 296);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(64, 319);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(64, 342);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(14, 13);
            this.radioButton3.TabIndex = 9;
            this.radioButton3.TabStop = true;
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(64, 365);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(14, 13);
            this.radioButton4.TabIndex = 10;
            this.radioButton4.TabStop = true;
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(85, 293);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(85, 316);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(85, 342);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 13;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(85, 368);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 20);
            this.textBox5.TabIndex = 14;
            // 
            // addAnotherQuesBtn
            // 
            this.addAnotherQuesBtn.Location = new System.Drawing.Point(64, 451);
            this.addAnotherQuesBtn.Name = "addAnotherQuesBtn";
            this.addAnotherQuesBtn.Size = new System.Drawing.Size(139, 23);
            this.addAnotherQuesBtn.TabIndex = 15;
            this.addAnotherQuesBtn.Text = "Add Another Question";
            this.addAnotherQuesBtn.UseVisualStyleBackColor = true;
            this.addAnotherQuesBtn.Click += new System.EventHandler(this.addAnotherQuesBtn_Click);
            // 
            // generateTestXMLBtn
            // 
            this.generateTestXMLBtn.Location = new System.Drawing.Point(209, 91);
            this.generateTestXMLBtn.Name = "generateTestXMLBtn";
            this.generateTestXMLBtn.Size = new System.Drawing.Size(139, 23);
            this.generateTestXMLBtn.TabIndex = 16;
            this.generateTestXMLBtn.Text = "Generate Test XML";
            this.generateTestXMLBtn.UseVisualStyleBackColor = true;
            this.generateTestXMLBtn.Click += new System.EventHandler(this.generateTestXMLBtn_Click);
            // 
            // endTestBtn
            // 
            this.endTestBtn.Location = new System.Drawing.Point(209, 451);
            this.endTestBtn.Name = "endTestBtn";
            this.endTestBtn.Size = new System.Drawing.Size(136, 23);
            this.endTestBtn.TabIndex = 17;
            this.endTestBtn.Text = "End Test Creation";
            this.endTestBtn.UseVisualStyleBackColor = true;
            this.endTestBtn.Click += new System.EventHandler(this.endTestBtn_Click);
            // 
            // textTypeAnswerTxt
            // 
            this.textTypeAnswerTxt.Location = new System.Drawing.Point(408, 296);
            this.textTypeAnswerTxt.Name = "textTypeAnswerTxt";
            this.textTypeAnswerTxt.Size = new System.Drawing.Size(156, 20);
            this.textTypeAnswerTxt.TabIndex = 18;
            // 
            // txtTypeAnswerLbl
            // 
            this.txtTypeAnswerLbl.AutoSize = true;
            this.txtTypeAnswerLbl.Location = new System.Drawing.Point(275, 299);
            this.txtTypeAnswerLbl.Name = "txtTypeAnswerLbl";
            this.txtTypeAnswerLbl.Size = new System.Drawing.Size(42, 13);
            this.txtTypeAnswerLbl.TabIndex = 19;
            this.txtTypeAnswerLbl.Text = "Answer";
            // 
            // essayAnsTxt
            // 
            this.essayAnsTxt.Location = new System.Drawing.Point(278, 369);
            this.essayAnsTxt.Multiline = true;
            this.essayAnsTxt.Name = "essayAnsTxt";
            this.essayAnsTxt.Size = new System.Drawing.Size(483, 79);
            this.essayAnsTxt.TabIndex = 20;
            // 
            // noOfKeywordsTxt
            // 
            this.noOfKeywordsTxt.Location = new System.Drawing.Point(408, 325);
            this.noOfKeywordsTxt.Name = "noOfKeywordsTxt";
            this.noOfKeywordsTxt.Size = new System.Drawing.Size(156, 20);
            this.noOfKeywordsTxt.TabIndex = 21;
            // 
            // noOfWordsLbl
            // 
            this.noOfWordsLbl.AutoSize = true;
            this.noOfWordsLbl.Location = new System.Drawing.Point(275, 325);
            this.noOfWordsLbl.Name = "noOfWordsLbl";
            this.noOfWordsLbl.Size = new System.Drawing.Size(103, 13);
            this.noOfWordsLbl.TabIndex = 22;
            this.noOfWordsLbl.Text = "Total No. of Words :";
            // 
            // essayKeywordsLbl
            // 
            this.essayKeywordsLbl.AutoSize = true;
            this.essayKeywordsLbl.Location = new System.Drawing.Point(275, 353);
            this.essayKeywordsLbl.Name = "essayKeywordsLbl";
            this.essayKeywordsLbl.Size = new System.Drawing.Size(59, 13);
            this.essayKeywordsLbl.TabIndex = 23;
            this.essayKeywordsLbl.Text = "Keywords :";
            // 
            // essayInstructionLbl
            // 
            this.essayInstructionLbl.AutoSize = true;
            this.essayInstructionLbl.ForeColor = System.Drawing.Color.Maroon;
            this.essayInstructionLbl.Location = new System.Drawing.Point(341, 353);
            this.essayInstructionLbl.Name = "essayInstructionLbl";
            this.essayInstructionLbl.Size = new System.Drawing.Size(209, 13);
            this.essayInstructionLbl.TabIndex = 24;
            this.essayInstructionLbl.Text = "Enter keywords separated by semi colon (;)";
            // 
            // uploadXMLBtn
            // 
            this.uploadXMLBtn.Location = new System.Drawing.Point(355, 91);
            this.uploadXMLBtn.Name = "uploadXMLBtn";
            this.uploadXMLBtn.Size = new System.Drawing.Size(153, 23);
            this.uploadXMLBtn.TabIndex = 25;
            this.uploadXMLBtn.Text = "Upload Test XML";
            this.uploadXMLBtn.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 859F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(222, 180);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(859, 144);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // essayAnswerRexponseTxt
            // 
            this.essayAnswerRexponseTxt.Location = new System.Drawing.Point(222, 325);
            this.essayAnswerRexponseTxt.Multiline = true;
            this.essayAnswerRexponseTxt.Name = "essayAnswerRexponseTxt";
            this.essayAnswerRexponseTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.essayAnswerRexponseTxt.Size = new System.Drawing.Size(859, 218);
            this.essayAnswerRexponseTxt.TabIndex = 29;
            // 
            // nextQuesBtn
            // 
            this.nextQuesBtn.Location = new System.Drawing.Point(64, 151);
            this.nextQuesBtn.Name = "nextQuesBtn";
            this.nextQuesBtn.Size = new System.Drawing.Size(139, 23);
            this.nextQuesBtn.TabIndex = 27;
            this.nextQuesBtn.Text = "Next Question >>";
            this.nextQuesBtn.UseVisualStyleBackColor = true;
            this.nextQuesBtn.Click += new System.EventHandler(this.nextQuesBtn_Click);
            // 
            // nextQuesLbl
            // 
            this.nextQuesLbl.AutoSize = true;
            this.nextQuesLbl.ForeColor = System.Drawing.Color.DarkRed;
            this.nextQuesLbl.Location = new System.Drawing.Point(219, 156);
            this.nextQuesLbl.Name = "nextQuesLbl";
            this.nextQuesLbl.Size = new System.Drawing.Size(609, 13);
            this.nextQuesLbl.TabIndex = 28;
            this.nextQuesLbl.Text = "Please check your answer twice before proceeding to next question as this questio" +
    "n will not be accessible after moving ahead !!";
            // 
            // submitTestBtn
            // 
            this.submitTestBtn.Location = new System.Drawing.Point(64, 564);
            this.submitTestBtn.Name = "submitTestBtn";
            this.submitTestBtn.Size = new System.Drawing.Size(238, 39);
            this.submitTestBtn.TabIndex = 30;
            this.submitTestBtn.Text = "Submit Test";
            this.submitTestBtn.UseVisualStyleBackColor = true;
            this.submitTestBtn.Click += new System.EventHandler(this.GenerateStudentsResponseXML);
            // 
            // textBox_info
            // 
            this.textBox_info.Location = new System.Drawing.Point(222, 87);
            this.textBox_info.Multiline = true;
            this.textBox_info.Name = "textBox_info";
            this.textBox_info.ReadOnly = true;
            this.textBox_info.Size = new System.Drawing.Size(700, 159);
            this.textBox_info.TabIndex = 31;
            // 
            // label_questype
            // 
            this.label_questype.AutoSize = true;
            this.label_questype.Location = new System.Drawing.Point(64, 210);
            this.label_questype.Name = "label_questype";
            this.label_questype.Size = new System.Drawing.Size(103, 13);
            this.label_questype.TabIndex = 32;
            this.label_questype.Text = "Select question type";
            this.label_questype.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1188, 628);
            this.Controls.Add(this.label_questype);
            this.Controls.Add(this.submitTestBtn);
            this.Controls.Add(this.nextQuesLbl);
            this.Controls.Add(this.nextQuesBtn);
            this.Controls.Add(this.uploadXMLBtn);
            this.Controls.Add(this.essayInstructionLbl);
            this.Controls.Add(this.essayKeywordsLbl);
            this.Controls.Add(this.noOfWordsLbl);
            this.Controls.Add(this.noOfKeywordsTxt);
            this.Controls.Add(this.essayAnsTxt);
            this.Controls.Add(this.txtTypeAnswerLbl);
            this.Controls.Add(this.textTypeAnswerTxt);
            this.Controls.Add(this.endTestBtn);
            this.Controls.Add(this.generateTestXMLBtn);
            this.Controls.Add(this.addAnotherQuesBtn);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.radioButton4);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.quesTxt);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.AddQuestionBtn);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.essayAnswerRexponseTxt);
            this.Controls.Add(this.textBox_info);
            this.Name = "Form1";
            this.Text = "Automated Test Creating and Grading Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void quesTxt_Validating(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button AddQuestionBtn;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox quesTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button addAnotherQuesBtn;
        private System.Windows.Forms.Button generateTestXMLBtn;
        private System.Windows.Forms.Button endTestBtn;
        private System.Windows.Forms.TextBox textTypeAnswerTxt;
        private System.Windows.Forms.Label txtTypeAnswerLbl;
        private System.Windows.Forms.TextBox essayAnsTxt;
        private System.Windows.Forms.TextBox noOfKeywordsTxt;
        private System.Windows.Forms.Label noOfWordsLbl;
        private System.Windows.Forms.Label essayKeywordsLbl;
        private System.Windows.Forms.Label essayInstructionLbl;
        private System.Windows.Forms.Button uploadXMLBtn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button nextQuesBtn;
        private System.Windows.Forms.Label nextQuesLbl;
        private System.Windows.Forms.TextBox essayAnswerRexponseTxt;
        private System.Windows.Forms.Button submitTestBtn;
        private System.Windows.Forms.TextBox textBox_info;
        private System.Windows.Forms.Label label_questype;
    }
}

