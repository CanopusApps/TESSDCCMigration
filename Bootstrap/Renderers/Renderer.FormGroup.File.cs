﻿using System.Web.Mvc;
using Bootstrap.ControlModels;
using Bootstrap.Controls;
using Bootstrap.TypeExtensions;

namespace Bootstrap.Renderers
{
    internal static partial class Renderer
    {
        public static string RenderFormGroupFile(HtmlHelper html, BootstrapFileModel inputModel, BootstrapLabelModel labelModel)
        {
            var input = Renderer.RenderFile(html, inputModel);

            string label = Renderer.RenderLabel(html, labelModel ?? new BootstrapLabelModel
            {
                htmlFieldName = inputModel.htmlFieldName,
                metadata = inputModel.metadata,
                htmlAttributes = new { @class = "control-label" }.ToDictionary()
            });

            bool fieldIsValid = true;
            if(inputModel != null) fieldIsValid = html.ViewData.ModelState.IsValidField(inputModel.htmlFieldName);
            return new BootstrapFormGroup(input, label, FormGroupType.textboxLike, fieldIsValid).ToHtmlString();
        }
    }
}
