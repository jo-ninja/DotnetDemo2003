#pragma once

#include "stdafx.h"

__gc class CppLib : public CSLibs::Cs
{
public:
	CppLib(void) : Cs(S"C++")
	{
	}

	CppLib(System::String* name) : Cs(name)
	{
	}
};
namespace CPPTester
{
	using namespace System;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;



	/// <summary> 
	/// Summary for Form1
	///
	/// WARNING: If you change the name of this class, you will need to change the 
	///          'Resource File Name' property for the managed resource compiler tool 
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public __gc class Form1 : public System::Windows::Forms::Form
	{	
	public:
		Form1(void)
		{
			InitializeComponent();
		}
  
	protected:
		void Dispose(Boolean disposing)
		{
			if (disposing && components)
			{
				components->Dispose();
			}
			__super::Dispose(disposing);
		}
	private: System::Windows::Forms::Button *  btnTes;

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container * components;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->btnTes = new System::Windows::Forms::Button();
			this->SuspendLayout();
			// 
			// btnTes
			// 
			this->btnTes->Location = System::Drawing::Point(64, 64);
			this->btnTes->Name = S"btnTes";
			this->btnTes->TabIndex = 0;
			this->btnTes->Text = S"&C++ Tes";
			this->btnTes->Click += new System::EventHandler(this, btnTes_Click);
			// 
			// Form1
			// 
			this->AutoScaleBaseSize = System::Drawing::Size(5, 13);
			this->ClientSize = System::Drawing::Size(208, 165);
			this->Controls->Add(this->btnTes);
			this->Name = S"Form1";
			this->Text = S"Form1";
			this->ResumeLayout(false);

		}	
	private: System::Void btnTes_Click(System::Object *  sender, System::EventArgs *  e)
			 {
				 CSLibs::Cs* cs = new CSLibs::Cs();
				 int result = cs->Add(5,3);
				 MessageBox::Show(result.ToString());

				 CppLib* cppLib = new CppLib();
				 MessageBox::Show(cppLib->Name);
			 }
	};

}


