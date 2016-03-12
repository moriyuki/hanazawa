namespace todolist_windows_form
{
    partial class FormTicketDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbEstimatedHours = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDoneRatio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.hsbDoneRatio = new System.Windows.Forms.HScrollBar();
            this.btnPublic = new System.Windows.Forms.Button();
            this.btnPrivate = new System.Windows.Forms.Button();
            this.cmbAuthor = new System.Windows.Forms.ComboBox();
            this.cmbPriority = new System.Windows.Forms.ComboBox();
            this.cmbbStatus = new System.Windows.Forms.ComboBox();
            this.cmbTracker = new System.Windows.Forms.ComboBox();
            this.cmbProject = new System.Windows.Forms.ComboBox();
            this.tbDueDate = new System.Windows.Forms.TextBox();
            this.tbStartDate = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.tbSubject = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblUpdated = new System.Windows.Forms.Label();
            this.lblClosed = new System.Windows.Forms.Label();
            this.lblCreated = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbEstimatedHours);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbDoneRatio);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.hsbDoneRatio);
            this.panel1.Controls.Add(this.btnPublic);
            this.panel1.Controls.Add(this.btnPrivate);
            this.panel1.Controls.Add(this.cmbAuthor);
            this.panel1.Controls.Add(this.cmbPriority);
            this.panel1.Controls.Add(this.cmbbStatus);
            this.panel1.Controls.Add(this.cmbTracker);
            this.panel1.Controls.Add(this.cmbProject);
            this.panel1.Controls.Add(this.tbDueDate);
            this.panel1.Controls.Add(this.tbStartDate);
            this.panel1.Controls.Add(this.tbDescription);
            this.panel1.Controls.Add(this.tbSubject);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblUpdated);
            this.panel1.Controls.Add(this.lblClosed);
            this.panel1.Controls.Add(this.lblCreated);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(472, 520);
            this.panel1.TabIndex = 0;
            // 
            // tbEstimatedHours
            // 
            this.tbEstimatedHours.Location = new System.Drawing.Point(132, 345);
            this.tbEstimatedHours.Name = "tbEstimatedHours";
            this.tbEstimatedHours.Size = new System.Drawing.Size(138, 19);
            this.tbEstimatedHours.TabIndex = 41;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 348);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 40;
            this.label3.Text = "予定工数";
            // 
            // tbDoneRatio
            // 
            this.tbDoneRatio.Location = new System.Drawing.Point(132, 377);
            this.tbDoneRatio.MaxLength = 4;
            this.tbDoneRatio.Name = "tbDoneRatio";
            this.tbDoneRatio.Size = new System.Drawing.Size(59, 19);
            this.tbDoneRatio.TabIndex = 37;
            this.tbDoneRatio.TextChanged += new System.EventHandler(this.tbDoneRatio_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(38, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 12);
            this.label7.TabIndex = 36;
            this.label7.Text = "公開・非公開";
            // 
            // hsbDoneRatio
            // 
            this.hsbDoneRatio.Location = new System.Drawing.Point(202, 378);
            this.hsbDoneRatio.Name = "hsbDoneRatio";
            this.hsbDoneRatio.Size = new System.Drawing.Size(184, 17);
            this.hsbDoneRatio.SmallChange = 10;
            this.hsbDoneRatio.TabIndex = 35;
            this.hsbDoneRatio.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hsbDoneRatio_Scroll);
            // 
            // btnPublic
            // 
            this.btnPublic.Location = new System.Drawing.Point(251, 410);
            this.btnPublic.Name = "btnPublic";
            this.btnPublic.Size = new System.Drawing.Size(85, 22);
            this.btnPublic.TabIndex = 34;
            this.btnPublic.Text = "公開";
            this.btnPublic.UseVisualStyleBackColor = true;
            // 
            // btnPrivate
            // 
            this.btnPrivate.Location = new System.Drawing.Point(132, 410);
            this.btnPrivate.Name = "btnPrivate";
            this.btnPrivate.Size = new System.Drawing.Size(85, 22);
            this.btnPrivate.TabIndex = 33;
            this.btnPrivate.Text = "非公開";
            this.btnPrivate.UseVisualStyleBackColor = true;
            // 
            // cmbAuthor
            // 
            this.cmbAuthor.FormattingEnabled = true;
            this.cmbAuthor.Location = new System.Drawing.Point(132, 192);
            this.cmbAuthor.Name = "cmbAuthor";
            this.cmbAuthor.Size = new System.Drawing.Size(85, 20);
            this.cmbAuthor.TabIndex = 32;
            // 
            // cmbPriority
            // 
            this.cmbPriority.FormattingEnabled = true;
            this.cmbPriority.Location = new System.Drawing.Point(132, 161);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Size = new System.Drawing.Size(85, 20);
            this.cmbPriority.TabIndex = 31;
            // 
            // cmbbStatus
            // 
            this.cmbbStatus.FormattingEnabled = true;
            this.cmbbStatus.Location = new System.Drawing.Point(132, 130);
            this.cmbbStatus.Name = "cmbbStatus";
            this.cmbbStatus.Size = new System.Drawing.Size(85, 20);
            this.cmbbStatus.TabIndex = 30;
            // 
            // cmbTracker
            // 
            this.cmbTracker.FormattingEnabled = true;
            this.cmbTracker.Location = new System.Drawing.Point(132, 99);
            this.cmbTracker.Name = "cmbTracker";
            this.cmbTracker.Size = new System.Drawing.Size(85, 20);
            this.cmbTracker.TabIndex = 29;
            // 
            // cmbProject
            // 
            this.cmbProject.FormattingEnabled = true;
            this.cmbProject.Location = new System.Drawing.Point(132, 68);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Size = new System.Drawing.Size(225, 20);
            this.cmbProject.TabIndex = 28;
            // 
            // tbDueDate
            // 
            this.tbDueDate.Location = new System.Drawing.Point(132, 313);
            this.tbDueDate.Name = "tbDueDate";
            this.tbDueDate.Size = new System.Drawing.Size(138, 19);
            this.tbDueDate.TabIndex = 26;
            // 
            // tbStartDate
            // 
            this.tbStartDate.Location = new System.Drawing.Point(132, 283);
            this.tbStartDate.Name = "tbStartDate";
            this.tbStartDate.Size = new System.Drawing.Size(138, 19);
            this.tbStartDate.TabIndex = 24;
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(132, 253);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(295, 19);
            this.tbDescription.TabIndex = 22;
            // 
            // tbSubject
            // 
            this.tbSubject.Location = new System.Drawing.Point(132, 223);
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Size = new System.Drawing.Size(295, 19);
            this.tbSubject.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 380);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 17;
            this.label15.Text = "進捗度";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 319);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "期限";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 257);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 15;
            this.label13.Text = "説明";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 226);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 14;
            this.label12.Text = "件名";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 102);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "トラッカー";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 12);
            this.label10.TabIndex = 12;
            this.label10.Text = "ステータス";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(38, 195);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 11;
            this.label9.Text = "作成者";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(38, 164);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 10;
            this.label8.Text = "優先度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "プロジェクト名";
            // 
            // lblUpdated
            // 
            this.lblUpdated.AutoSize = true;
            this.lblUpdated.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblUpdated.Location = new System.Drawing.Point(309, 27);
            this.lblUpdated.Name = "lblUpdated";
            this.lblUpdated.Size = new System.Drawing.Size(160, 11);
            this.lblUpdated.TabIndex = 5;
            this.lblUpdated.Text = "最終更新日：yyyy/mm/dd-hh:mm";
            // 
            // lblClosed
            // 
            this.lblClosed.AutoSize = true;
            this.lblClosed.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblClosed.Location = new System.Drawing.Point(309, 38);
            this.lblClosed.Name = "lblClosed";
            this.lblClosed.Size = new System.Drawing.Size(138, 11);
            this.lblClosed.TabIndex = 5;
            this.lblClosed.Text = "完了日：yyyy/mm/dd-hh:mm";
            // 
            // lblCreated
            // 
            this.lblCreated.AutoSize = true;
            this.lblCreated.Font = new System.Drawing.Font("MS UI Gothic", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCreated.Location = new System.Drawing.Point(309, 16);
            this.lblCreated.Name = "lblCreated";
            this.lblCreated.Size = new System.Drawing.Size(135, 11);
            this.lblCreated.TabIndex = 4;
            this.lblCreated.Text = "作成日：yyyy/mm/dd hh:mm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 288);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "開始日";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "チケットID：0000";
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnCancel.Location = new System.Drawing.Point(101, 463);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(116, 35);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnOk.Location = new System.Drawing.Point(251, 463);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(116, 35);
            this.btnOk.TabIndex = 38;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // FormTicketDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 544);
            this.Controls.Add(this.panel1);
            this.Name = "FormTicketDetail";
            this.Text = "FormTicketDetail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCreated;
        private System.Windows.Forms.Label lblClosed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbSubject;
        private System.Windows.Forms.TextBox tbStartDate;
        private System.Windows.Forms.TextBox tbDueDate;
        private System.Windows.Forms.ComboBox cmbProject;
        private System.Windows.Forms.ComboBox cmbTracker;
        private System.Windows.Forms.ComboBox cmbbStatus;
        private System.Windows.Forms.ComboBox cmbPriority;
        private System.Windows.Forms.ComboBox cmbAuthor;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button btnPrivate;
        private System.Windows.Forms.Button btnPublic;
        private System.Windows.Forms.Label lblUpdated;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.HScrollBar hsbDoneRatio;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TextBox tbDoneRatio;
        private System.Windows.Forms.TextBox tbEstimatedHours;
        private System.Windows.Forms.Label label3;
    }
}