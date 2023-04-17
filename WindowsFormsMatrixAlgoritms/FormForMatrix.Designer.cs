
namespace WindowsFormsMatrixAlgoritms
{
    partial class FormForMatrix
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.labelLengths = new System.Windows.Forms.Label();
            this.FullSearchResult = new System.Windows.Forms.TextBox();
            this.AntColonyResult = new System.Windows.Forms.TextBox();
            this.NearestNeighbourResult = new System.Windows.Forms.TextBox();
            this.BranchesAndBoundariesResult = new System.Windows.Forms.TextBox();
            this.ImprovedNearestNeighbourResult = new System.Windows.Forms.TextBox();
            this.SimulatedAnnealingResult = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chartMatrix = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMatrix)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLengths
            // 
            this.labelLengths.AutoSize = true;
            this.labelLengths.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLengths.Location = new System.Drawing.Point(14, 362);
            this.labelLengths.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLengths.Name = "labelLengths";
            this.labelLengths.Size = new System.Drawing.Size(343, 32);
            this.labelLengths.TabIndex = 8;
            this.labelLengths.Text = "Оценка точности алгоритмов";
            // 
            // FullSearchResult
            // 
            this.FullSearchResult.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FullSearchResult.Location = new System.Drawing.Point(20, 398);
            this.FullSearchResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FullSearchResult.Name = "FullSearchResult";
            this.FullSearchResult.Size = new System.Drawing.Size(326, 45);
            this.FullSearchResult.TabIndex = 2;
            // 
            // AntColonyResult
            // 
            this.AntColonyResult.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AntColonyResult.Location = new System.Drawing.Point(20, 698);
            this.AntColonyResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AntColonyResult.Name = "AntColonyResult";
            this.AntColonyResult.Size = new System.Drawing.Size(326, 45);
            this.AntColonyResult.TabIndex = 7;
            // 
            // NearestNeighbourResult
            // 
            this.NearestNeighbourResult.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NearestNeighbourResult.Location = new System.Drawing.Point(20, 458);
            this.NearestNeighbourResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NearestNeighbourResult.Name = "NearestNeighbourResult";
            this.NearestNeighbourResult.Size = new System.Drawing.Size(326, 45);
            this.NearestNeighbourResult.TabIndex = 3;
            // 
            // BranchesAndBoundariesResult
            // 
            this.BranchesAndBoundariesResult.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BranchesAndBoundariesResult.Location = new System.Drawing.Point(20, 638);
            this.BranchesAndBoundariesResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BranchesAndBoundariesResult.Name = "BranchesAndBoundariesResult";
            this.BranchesAndBoundariesResult.Size = new System.Drawing.Size(326, 45);
            this.BranchesAndBoundariesResult.TabIndex = 6;
            // 
            // ImprovedNearestNeighbourResult
            // 
            this.ImprovedNearestNeighbourResult.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ImprovedNearestNeighbourResult.Location = new System.Drawing.Point(20, 518);
            this.ImprovedNearestNeighbourResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImprovedNearestNeighbourResult.Name = "ImprovedNearestNeighbourResult";
            this.ImprovedNearestNeighbourResult.Size = new System.Drawing.Size(326, 45);
            this.ImprovedNearestNeighbourResult.TabIndex = 4;
            // 
            // SimulatedAnnealingResult
            // 
            this.SimulatedAnnealingResult.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SimulatedAnnealingResult.Location = new System.Drawing.Point(20, 578);
            this.SimulatedAnnealingResult.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SimulatedAnnealingResult.Name = "SimulatedAnnealingResult";
            this.SimulatedAnnealingResult.Size = new System.Drawing.Size(326, 45);
            this.SimulatedAnnealingResult.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.labelLengths);
            this.panel1.Controls.Add(this.FullSearchResult);
            this.panel1.Controls.Add(this.AntColonyResult);
            this.panel1.Controls.Add(this.NearestNeighbourResult);
            this.panel1.Controls.Add(this.BranchesAndBoundariesResult);
            this.panel1.Controls.Add(this.ImprovedNearestNeighbourResult);
            this.panel1.Controls.Add(this.SimulatedAnnealingResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(1028, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 791);
            this.panel1.TabIndex = 11;
            // 
            // chartMatrix
            // 
            chartArea1.Name = "ChartArea1";
            this.chartMatrix.ChartAreas.Add(chartArea1);
            this.chartMatrix.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartMatrix.Legends.Add(legend1);
            this.chartMatrix.Location = new System.Drawing.Point(0, 0);
            this.chartMatrix.Name = "chartMatrix";
            this.chartMatrix.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series1.BorderColor = System.Drawing.Color.Transparent;
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.SlateBlue;
            series1.Legend = "Legend1";
            series1.Name = "Классический алгоритм";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Алгоритм Штраусенна";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Legend = "Legend1";
            series3.Name = "Алгоритм Винограда";
            series4.BorderWidth = 3;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Алгоритм 4 русских";
            this.chartMatrix.Series.Add(series1);
            this.chartMatrix.Series.Add(series2);
            this.chartMatrix.Series.Add(series3);
            this.chartMatrix.Series.Add(series4);
            this.chartMatrix.Size = new System.Drawing.Size(1028, 791);
            this.chartMatrix.TabIndex = 12;
            this.chartMatrix.Text = "chart1";
            // 
            // FormForMatrix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1396, 791);
            this.Controls.Add(this.chartMatrix);
            this.Controls.Add(this.panel1);
            this.Name = "FormForMatrix";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartMatrix)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelLengths;
        private System.Windows.Forms.TextBox FullSearchResult;
        private System.Windows.Forms.TextBox AntColonyResult;
        private System.Windows.Forms.TextBox NearestNeighbourResult;
        private System.Windows.Forms.TextBox BranchesAndBoundariesResult;
        private System.Windows.Forms.TextBox ImprovedNearestNeighbourResult;
        private System.Windows.Forms.TextBox SimulatedAnnealingResult;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartMatrix;
    }
}

