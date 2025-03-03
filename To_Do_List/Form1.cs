﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace To_Do_List
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        DataTable todoList = new DataTable();

        bool isEditing = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            //Kolon oluşruyoruz 
            todoList.Columns.Add("Title");
            todoList.Columns.Add("Description");

            toDoListView.DataSource = todoList;

        }

        private void newButton_Click(object sender, EventArgs e)
        {
            textBox1.Text ="";
            textBox2.Text = "";

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            isEditing = true;

            textBox1.Text = todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[0].ToString();
            textBox2.Text= todoList.Rows[toDoListView.CurrentCell.RowIndex].ItemArray[1].ToString();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex) {
                Console.WriteLine("Error: "+ex.ToString());
          
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (isEditing)
            {
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Title"]= textBox1.Text;
                todoList.Rows[toDoListView.CurrentCell.RowIndex]["Description"] = textBox2.Text;
            }
            else {
            todoList.Rows.Add (textBox1.Text, textBox2.Text);

            }
            textBox1.Text = "";
            textBox2.Text = "";
            isEditing = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
