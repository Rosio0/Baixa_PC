namespace Baixa_PC
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtNIFAluno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnInserir = new System.Windows.Forms.Button();
            this.txtPortNumSer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPortTipo = new System.Windows.Forms.TextBox();
            this.chkSegundaViaSim = new System.Windows.Forms.CheckBox();
            this.chkMochilaEntregue = new System.Windows.Forms.CheckBox();
            this.chkFonesEntregue = new System.Windows.Forms.CheckBox();
            this.chkPcEntregue = new System.Windows.Forms.CheckBox();
            this.chkAberturaFecho = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomeAluno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDataEntrega = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObservacoes = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAnoEscolaridade = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTurma = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNomeEE = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtNIFEE = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtPortImobilizado = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtHostPotNumSer = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtSimNumSer = new System.Windows.Forms.TextBox();
            this.chkEcraLogin = new System.Windows.Forms.CheckBox();
            this.chkFormatado = new System.Windows.Forms.CheckBox();
            this.btnGerarPDF = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPesquisaNIF = new System.Windows.Forms.TextBox();
            this.btnAtualizarr = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNIFAluno
            // 
            this.txtNIFAluno.Location = new System.Drawing.Point(35, 144);
            this.txtNIFAluno.Name = "txtNIFAluno";
            this.txtNIFAluno.Size = new System.Drawing.Size(92, 20);
            this.txtNIFAluno.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "NIF Aluno";
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(163, 86);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(75, 23);
            this.btnInserir.TabIndex = 2;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click_1);
            // 
            // txtPortNumSer
            // 
            this.txtPortNumSer.Location = new System.Drawing.Point(44, 263);
            this.txtPortNumSer.Name = "txtPortNumSer";
            this.txtPortNumSer.Size = new System.Drawing.Size(110, 20);
            this.txtPortNumSer.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 247);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nº Série Computador";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(167, 247);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tipo (1 , 2 , 3)";
            // 
            // txtPortTipo
            // 
            this.txtPortTipo.Location = new System.Drawing.Point(170, 263);
            this.txtPortTipo.Name = "txtPortTipo";
            this.txtPortTipo.Size = new System.Drawing.Size(57, 20);
            this.txtPortTipo.TabIndex = 5;
            // 
            // chkSegundaViaSim
            // 
            this.chkSegundaViaSim.AutoSize = true;
            this.chkSegundaViaSim.Location = new System.Drawing.Point(183, 323);
            this.chkSegundaViaSim.Name = "chkSegundaViaSim";
            this.chkSegundaViaSim.Size = new System.Drawing.Size(76, 17);
            this.chkSegundaViaSim.TabIndex = 8;
            this.chkSegundaViaSim.Text = "2º Via SIM";
            this.chkSegundaViaSim.UseVisualStyleBackColor = true;
            // 
            // chkMochilaEntregue
            // 
            this.chkMochilaEntregue.AutoSize = true;
            this.chkMochilaEntregue.Location = new System.Drawing.Point(183, 369);
            this.chkMochilaEntregue.Name = "chkMochilaEntregue";
            this.chkMochilaEntregue.Size = new System.Drawing.Size(63, 17);
            this.chkMochilaEntregue.TabIndex = 9;
            this.chkMochilaEntregue.Text = "Mochila";
            this.chkMochilaEntregue.UseVisualStyleBackColor = true;
            // 
            // chkFonesEntregue
            // 
            this.chkFonesEntregue.AutoSize = true;
            this.chkFonesEntregue.Location = new System.Drawing.Point(183, 392);
            this.chkFonesEntregue.Name = "chkFonesEntregue";
            this.chkFonesEntregue.Size = new System.Drawing.Size(55, 17);
            this.chkFonesEntregue.TabIndex = 10;
            this.chkFonesEntregue.Text = "Fones";
            this.chkFonesEntregue.UseVisualStyleBackColor = true;
            // 
            // chkPcEntregue
            // 
            this.chkPcEntregue.AutoSize = true;
            this.chkPcEntregue.Location = new System.Drawing.Point(183, 346);
            this.chkPcEntregue.Name = "chkPcEntregue";
            this.chkPcEntregue.Size = new System.Drawing.Size(86, 17);
            this.chkPcEntregue.TabIndex = 11;
            this.chkPcEntregue.Text = "PC Entregue";
            this.chkPcEntregue.UseVisualStyleBackColor = true;
            // 
            // chkAberturaFecho
            // 
            this.chkAberturaFecho.AutoSize = true;
            this.chkAberturaFecho.Location = new System.Drawing.Point(287, 323);
            this.chkAberturaFecho.Name = "chkAberturaFecho";
            this.chkAberturaFecho.Size = new System.Drawing.Size(89, 17);
            this.chkAberturaFecho.TabIndex = 12;
            this.chkAberturaFecho.Text = "Abre / Fecha";
            this.chkAberturaFecho.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(146, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Nome do Aluno";
            // 
            // txtNomeAluno
            // 
            this.txtNomeAluno.Location = new System.Drawing.Point(146, 144);
            this.txtNomeAluno.Name = "txtNomeAluno";
            this.txtNomeAluno.Size = new System.Drawing.Size(253, 20);
            this.txtNomeAluno.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 525);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Data de Entrega";
            // 
            // dtpDataEntrega
            // 
            this.dtpDataEntrega.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtpDataEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataEntrega.Location = new System.Drawing.Point(38, 542);
            this.dtpDataEntrega.Name = "dtpDataEntrega";
            this.dtpDataEntrega.Size = new System.Drawing.Size(200, 20);
            this.dtpDataEntrega.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(277, 247);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 19;
            this.label7.Text = "Estado ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 445);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Observações";
            // 
            // txtObservacoes
            // 
            this.txtObservacoes.Location = new System.Drawing.Point(38, 461);
            this.txtObservacoes.Multiline = true;
            this.txtObservacoes.Name = "txtObservacoes";
            this.txtObservacoes.Size = new System.Drawing.Size(231, 57);
            this.txtObservacoes.TabIndex = 20;
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "",
            "Em stock",
            "Entregue",
            "Avariado",
            "Reparado"});
            this.cmbEstado.Location = new System.Drawing.Point(280, 263);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(90, 21);
            this.cmbEstado.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(412, 128);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Ano ";
            // 
            // txtAnoEscolaridade
            // 
            this.txtAnoEscolaridade.Location = new System.Drawing.Point(415, 144);
            this.txtAnoEscolaridade.Name = "txtAnoEscolaridade";
            this.txtAnoEscolaridade.Size = new System.Drawing.Size(39, 20);
            this.txtAnoEscolaridade.TabIndex = 24;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(484, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(37, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Turma";
            // 
            // txtTurma
            // 
            this.txtTurma.Location = new System.Drawing.Point(481, 144);
            this.txtTurma.Name = "txtTurma";
            this.txtTurma.Size = new System.Drawing.Size(39, 20);
            this.txtTurma.TabIndex = 26;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(188, 188);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(166, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "Nome do Encarregado Educação";
            // 
            // txtNomeEE
            // 
            this.txtNomeEE.Location = new System.Drawing.Point(188, 204);
            this.txtNomeEE.Name = "txtNomeEE";
            this.txtNomeEE.Size = new System.Drawing.Size(253, 20);
            this.txtNomeEE.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(34, 188);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "NIF Encarregado Educação";
            // 
            // txtNIFEE
            // 
            this.txtNIFEE.Location = new System.Drawing.Point(34, 204);
            this.txtNIFEE.Name = "txtNIFEE";
            this.txtNIFEE.Size = new System.Drawing.Size(92, 20);
            this.txtNIFEE.TabIndex = 28;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(38, 307);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 33;
            this.label13.Text = "PortImobilizado";
            // 
            // txtPortImobilizado
            // 
            this.txtPortImobilizado.Location = new System.Drawing.Point(38, 323);
            this.txtPortImobilizado.Name = "txtPortImobilizado";
            this.txtPortImobilizado.Size = new System.Drawing.Size(110, 20);
            this.txtPortImobilizado.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(38, 354);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(81, 13);
            this.label14.TabIndex = 35;
            this.label14.Text = "Nº Série Router";
            // 
            // txtHostPotNumSer
            // 
            this.txtHostPotNumSer.Location = new System.Drawing.Point(38, 370);
            this.txtHostPotNumSer.Name = "txtHostPotNumSer";
            this.txtHostPotNumSer.Size = new System.Drawing.Size(110, 20);
            this.txtHostPotNumSer.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(38, 399);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 37;
            this.label15.Text = "Nº Série SIM";
            // 
            // txtSimNumSer
            // 
            this.txtSimNumSer.Location = new System.Drawing.Point(38, 415);
            this.txtSimNumSer.Name = "txtSimNumSer";
            this.txtSimNumSer.Size = new System.Drawing.Size(110, 20);
            this.txtSimNumSer.TabIndex = 36;
            // 
            // chkEcraLogin
            // 
            this.chkEcraLogin.AutoSize = true;
            this.chkEcraLogin.Location = new System.Drawing.Point(287, 346);
            this.chkEcraLogin.Name = "chkEcraLogin";
            this.chkEcraLogin.Size = new System.Drawing.Size(52, 17);
            this.chkEcraLogin.TabIndex = 38;
            this.chkEcraLogin.Text = "Login";
            this.chkEcraLogin.UseVisualStyleBackColor = true;
            // 
            // chkFormatado
            // 
            this.chkFormatado.AutoSize = true;
            this.chkFormatado.Location = new System.Drawing.Point(287, 369);
            this.chkFormatado.Name = "chkFormatado";
            this.chkFormatado.Size = new System.Drawing.Size(76, 17);
            this.chkFormatado.TabIndex = 39;
            this.chkFormatado.Text = "Formatado";
            this.chkFormatado.UseVisualStyleBackColor = true;
            // 
            // btnGerarPDF
            // 
            this.btnGerarPDF.Location = new System.Drawing.Point(455, 70);
            this.btnGerarPDF.Name = "btnGerarPDF";
            this.btnGerarPDF.Size = new System.Drawing.Size(75, 23);
            this.btnGerarPDF.TabIndex = 40;
            this.btnGerarPDF.Text = "Gerar PDF";
            this.btnGerarPDF.UseVisualStyleBackColor = true;
            this.btnGerarPDF.Click += new System.EventHandler(this.btnGerarPDF_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Pesquisa NIF (Aluno / EE)";
            // 
            // txtPesquisaNIF
            // 
            this.txtPesquisaNIF.Location = new System.Drawing.Point(34, 86);
            this.txtPesquisaNIF.Name = "txtPesquisaNIF";
            this.txtPesquisaNIF.Size = new System.Drawing.Size(92, 20);
            this.txtPesquisaNIF.TabIndex = 0;
            // 
            // btnAtualizarr
            // 
            this.btnAtualizarr.Location = new System.Drawing.Point(455, 539);
            this.btnAtualizarr.Name = "btnAtualizarr";
            this.btnAtualizarr.Size = new System.Drawing.Size(75, 23);
            this.btnAtualizarr.TabIndex = 44;
            this.btnAtualizarr.Text = "Atualizar";
            this.btnAtualizarr.UseVisualStyleBackColor = true;
            this.btnAtualizarr.Click += new System.EventHandler(this.btnAtualizarr_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(358, 539);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpar.TabIndex = 45;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(355, 505);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(176, 13);
            this.lblStatus.TabIndex = 46;
            this.lblStatus.Text = "🔄 Atualizando, por favor aguarde...";
            this.lblStatus.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Baixa_PC.Properties.Resources.ESPN_1;
            this.pictureBox1.Location = new System.Drawing.Point(329, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(221, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 47;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Baixa_PC.Properties.Resources.RPE;
            this.pictureBox2.Location = new System.Drawing.Point(24, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(150, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 48;
            this.pictureBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(255)))), ((int)(((byte)(189)))));
            this.ClientSize = new System.Drawing.Size(562, 574);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAtualizarr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPesquisaNIF);
            this.Controls.Add(this.btnGerarPDF);
            this.Controls.Add(this.chkFormatado);
            this.Controls.Add(this.chkEcraLogin);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txtSimNumSer);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txtHostPotNumSer);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtPortImobilizado);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtNomeEE);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNIFEE);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtTurma);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAnoEscolaridade);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtObservacoes);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDataEntrega);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNomeAluno);
            this.Controls.Add(this.chkAberturaFecho);
            this.Controls.Add(this.chkPcEntregue);
            this.Controls.Add(this.chkFonesEntregue);
            this.Controls.Add(this.chkMochilaEntregue);
            this.Controls.Add(this.chkSegundaViaSim);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPortTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPortNumSer);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNIFAluno);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Baixa_PC";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNIFAluno;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.TextBox txtPortNumSer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPortTipo;
        private System.Windows.Forms.CheckBox chkSegundaViaSim;
        private System.Windows.Forms.CheckBox chkMochilaEntregue;
        private System.Windows.Forms.CheckBox chkFonesEntregue;
        private System.Windows.Forms.CheckBox chkPcEntregue;
        private System.Windows.Forms.CheckBox chkAberturaFecho;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomeAluno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDataEntrega;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObservacoes;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAnoEscolaridade;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTurma;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNomeEE;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtNIFEE;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtPortImobilizado;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtHostPotNumSer;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtSimNumSer;
        private System.Windows.Forms.CheckBox chkEcraLogin;
        private System.Windows.Forms.CheckBox chkFormatado;
        private System.Windows.Forms.Button btnGerarPDF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPesquisaNIF;
        private System.Windows.Forms.Button btnAtualizarr;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

