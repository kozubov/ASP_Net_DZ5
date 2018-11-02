# ASP_Net_DZ5

Continue work on the library, add controllers for managing users and roles (combine work with users from previous ts with the previous one (with books))<br/>
If not applied, apply attributes to model properties (Display, Requried, DateType - if necessary, etc. attributes applied to model attributes in the file), respectively, use the Html helper to generate input fields (Html.EditorFor ) and labels (Html.LabelFor) forms.

Validation of data carried out on the server (ModelState.IsValid)<br/>
To generate tables, use helpers, preferably cs files (extension methods HtmlHelper), as in the example.<br/>

+ in the helper check for the presence of the scaffoldColumn attribute, if there is, check the value of the Scaffold property in the attribute, if false - do not display this column
