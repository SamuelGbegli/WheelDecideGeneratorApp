using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelDecideGeneratorApp
{
    /// <summary>
    /// Renders segment output values as text to be copied and pasted.
    /// </summary>
    public class TextOutput
    {
        /// <summary>
        /// The output values rendered as a string, joined with line breaks.
        /// </summary>
        public string ValueString { get; set; }
        /// <summary>
        /// The output background colours as a string, joined with commas.
        /// </summary>
        public string BackgroundColourString { get; set; }
        /// <summary>
        /// The output text colours as a string, joined with commas.
        /// </summary>
        public string TextColourString { get; set; }
        /// <summary>
        /// The output weight values as a string, joined with commas.
        /// </summary>
        public string WeightString { get; set; }
        /// <summary>
        /// A URL the user can directly go to with the values pre-populated.
        /// </summary>
        public string URL { get; set; }

        /// <summary>
        /// Converts a list to data that can be copied.
        /// </summary>
        /// <param name="segmentOutputs">The list to be converted.</param>
        public TextOutput(List<SegmentOutput> segmentOutputs)
        {
            ValueString = string.Join("\n", segmentOutputs.Select(s => s.Value));
            BackgroundColourString = string.Join(",", segmentOutputs.Select(s => s.BackgroundColour));
            TextColourString = string.Join(",", segmentOutputs.Select(s => s.TextColour));
            WeightString = string.Join(",", segmentOutputs.Select(s => s.Weight));

            //Generates url
            var urlBuilder= new StringBuilder("https://wheeldecide.com/?");
            for (int i = 1; i <= segmentOutputs.Count; i++)
            {
                urlBuilder.Append($"c{i}={segmentOutputs[i - 1].Value}");
                if (segmentOutputs[i - 1] != segmentOutputs.Last()) urlBuilder.Append("&");
            }
            urlBuilder.Append($"&cols={BackgroundColourString}&time=5&tcol={TextColourString}&weights={WeightString}");
            URL = urlBuilder.ToString();
        }
    }
}
