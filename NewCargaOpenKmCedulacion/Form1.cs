using com.openkm.sdk4csharp;
using com.openkm.sdk4csharp.bean;

using com.openkm.sdk4csharp.impl;

using Serilog;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;

using System.Threading;
using System.Windows.Forms;
using PdfSharp.Pdf.Advanced;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using System.Linq;
using System.Drawing;

namespace NewCargaOpenKmCedulacion
{
    public partial class Form1 : Form
    {
        private string host = "";
        private string username = "";
        private string password = "";
        private OKMWebservices ws = new OKMWebservices("");
        public SqlConnection Conn;
        public bool ErrorDoc;
        private List<string> ListaDocumentos = new List<string>();
        private int ConError = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private string getInstancia()
        {
            switch (Instancia.Text) {
                case "CEDULACION":
                    return "http://172.16.35.69:8080/openkm/";
                case "REGISTRO CIVIL":
                    return "http://172.16.35.50:8080/openkm/";
                case "ORGANIZACION ELECTORAL":
                    return "http://172.16.35.86:8080/openkm/";
                default:
                    return "";
            }
        }

        private bool isCedulacion()
        {
            if (Instancia.Text == "CEDULACION")
                return true;
            return false;
        }

        private bool isRc()
        {
            if (Instancia.Text == "REGISTRO CIVIL")
                return true;
            return false;
        }
        private string getRutaOpenkm()
        {
            switch (Instancia.Text) {
                case "CEDULACION":
                    return "/okm:root/DIGITALIZACIÓN/";
                case "REGISTRO CIVIL":
                    return "/okm:root/DIGITALIZACION/";
                case "ORGANIZACION ELECTORAL":
                    return "/okm:root/DIGITALIZACION/";
                default:
                    return "";
            }
        }

        private string getCarpetaError()
        {
            switch (Instancia.Text) {
                case "CEDULACION":
                    return "9735b4fd-64a6-406e-9755-1fddeab597fa";
                case "REGISTRO CIVIL":
                    return "d45f7428-2a71-465d-897b-79992981e611";
                case "ORGANIZACION ELECTORAL":
                    return "b96896da-5572-41ed-aba6-cebdd20a052d";
                default:
                    return "";
            }
        }


        //DE Num_Defuncion
        //MA Num_Matrimonio

        private string getCampo()
        {
            string campo = "Num_Inscripcion";

            if (Instancia.Text == "REGISTRO CIVIL") {
                if (MetaDato.Text.Contains("RC_DE"))
                    campo = "Num_Defuncion";
                if (MetaDato.Text.Contains("RC_MA"))
                    campo = "Num_Matrimonio";
            }

            return campo;
        }


        private string getFlujo()
        {
            Log.Information("GetFlujo() Metadato: " + MetaDato.Text);

            //Es Instancia ceculacion
            if (isCedulacion()) {
                if (MetaDato.Text.StartsWith("CED_POSITIVOS"))
                    return "GIRO_DIARIO_POS";

                return "CED_GIRO_DIARIO";
            }
            //Es RC
            else if (isRc()) {

                string metadato = MetaDato.Text;

                if (metadato.StartsWith("RC_NA_INSCRIPCIONES"))
                    return "GIRO_DIARIO_NAC_INSCRIPCIONES";

                if (metadato.StartsWith("RC_DE_INSCRIPCIONES"))
                    return "GIRO_DIARIO_DEF_INSCRIPCIONES";

                if (metadato.StartsWith("RC_MA_INSCRIPCIONES"))
                    return "GIRO_DIARIO_MAT_INSCRIPCIONES";

                if (metadato.StartsWith("RC_NA_ANOTACIONES"))
                    return "GIRO_DIARIO_NAC_ANOT";

                if (metadato.StartsWith("RC_NA_RESOLUCIONES"))
                    return "GIRO_DIARIO_NAC_RES";

                if (metadato.StartsWith("RC_MA_ANOTACIONES"))
                    return "GIRO_DIARIO_MAT_ANOT";

                if (metadato.StartsWith("RC_MA_RESOLUCIONES"))
                    return "GIRO_DIARIO_MAT_RES";

                if (metadato.StartsWith("RC_DE_ANOTACIONES"))
                    return "GIRO_DIARIO_DEF_ANOT";

                if (metadato.StartsWith("RC_DE_RESOLUCIONES"))
                    return "GIRO_DIARIO_DEF_RES";

                if (metadato.StartsWith("RC_NA_PARTES_CLINICOS"))
                    return "GIRO_DIARIO_PARTES_CLIN";

                if (metadato.StartsWith("RC_NA_BAUTIMOS"))
                    return "GIRO_DIARIO_BAUTISMO";

                if (metadato.StartsWith("RC_ADOPCIONES"))
                    return "GIRO_DIARIO_ADOPCIONES";

                if (metadato.StartsWith("RC_CERTIFICACIONES"))
                    return "GIRO_DIARIO_CERTIFICACIONES";

            }
            // ES ORGANIZACION ELECTORAL
            else {

                string metadato = MetaDato.Text;

                if (metadato.StartsWith("OE_CAMBIOS_RESIDENCIA"))
                    return "GIRO_DIARIO_CAMBIO_RES";

                if (metadato.StartsWith("OE_ACTA_MESA"))
                    return "GIRO_DIARIO_ACTA_MESA";

                if (metadato.StartsWith("OE_TER"))
                    return "GIRO_DIARIO_TER";

                if (metadato.StartsWith("OE_PADRONES"))
                    return "GIRO_DIARIO_PADRONES";

                if (metadato.StartsWith("AH_BAUTIMOS"))
                    return "GIRO_DIARIO_AH_BAUTISMO";

                if (metadato.StartsWith("AH_MATRIMONIOS"))
                    return "GIRO_DIARIO_AH_MAT";

                if (metadato.StartsWith("AH_DEFUNCIONES"))
                    return "GIRO_DIARIO_AH_DEF";

                if (metadato.StartsWith("OE_RENUNCIA_PARTIDOS"))
                    return "GIRO_DIARIO_RENUNCIA_PP";

                if (metadato.StartsWith("OE_INSCRIPCION_PARTIDOS"))
                    return "GIRO_DIARIO_INSCRIPCION_PP";

                if (metadato.StartsWith("OE_ACTA_JUNTA_REPRESENTANTE"))
                    return "OE_ACTA_JUNTA_REPRESENTANTE";

                if (metadato.StartsWith("OE_ACTA_JUNTA_PRESIDENTE"))
                    return "OE_ACTA_JUNTA_PRESIDENTE";

                if (metadato.StartsWith("OE_ACTA_JUNTA_DIPUTADO"))
                    return "OE_ACTA_JUNTA_DIPUTADO";

                if (metadato.StartsWith("OE_ACTA_JUNTA_CIRCUITAL"))
                    return "OE_ACTA_JUNTA_CIRCUITAL";

                if (metadato.StartsWith("OE_ACTA_JUNTA_ALCALDE"))
                    return "OE_ACTA_JUNTA_ALCALDE";

                if (metadato.StartsWith("OE_ACTA_JUNTA_CONCEJAL"))
                    return "OE_ACTA_JUNTA_CONCEJAL";
            }
            return "";
        }

        private void RunWorkFlow(string Cedula, string IdDocOpenkm, string Doc)
        {
            string flujo = getFlujo();
            // MessageBox.Show("Flujo: " + flujo + ":" + getCampo() + "\n\n" + IdDocOpenkm);
            Log.Information("Flujo: " + flujo + ":" + getCampo() + "\n\n" + IdDocOpenkm);

            if (!string.IsNullOrEmpty(flujo)) {
                try {
                    ProcessDefinition pd = ws.workflow.findLastProcessDefinition(flujo);
                    if (pd != null) {
                        Dictionary<string, string> props = new Dictionary<string, string>();
                        props.Add(flujo + ":" + getCampo(), Cedula);
                        ProcessInstance pi = ws.workflow.runProcessDefinition(pd.id, IdDocOpenkm, props);
                        Log.Information("WORKFLOW INICIADO!!! \npi = " + pi.id + " " + pi.processDefinition.name);
                        
                    }
                    else {
                        Log.Error($"Error at ProcessDefinition: ws.workflow.findLastProcessDefinition with flujo = {flujo} was null");
                    }
                }
                catch (Exception ex) {
                    Log.Error(ex, $"No se logro activar flujo {flujo} con Doc: {Doc} ");

                    try {
                        ws.document.moveDocument(IdDocOpenkm, getCarpetaError());
                    }
                    catch (Exception ex2) {
                        Log.Error(ex2, $"No se pudo mover DOC:{IdDocOpenkm} a  {getCarpetaError()}");
                        MessageBox.Show(
                            $"No se pudo mover DOC:{IdDocOpenkm} a  {getCarpetaError()}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }

        private void IniciarProceso_Click(object sender, EventArgs e)
        {
            if (Instancia.SelectedIndex == -1 || MetaDato.SelectedIndex == -1) {
                MessageBox.Show("Instancia y Metadato deben estar seleccionados!");
                return;
            }

            Log.Information($"Start work with Instancia:{Instancia.Text}, Metadato: {MetaDato.Text}");
            Log.Information($"Directorio: {DirectorioFuentes.Text}, #Archivos: {Cantidad.Text}");
            ResetUI();
            host = getInstancia();
            IniciarProceso.Enabled = false;

            if (!ConexionOpenKM()) {
                MessageBox.Show("No se pudo conectar a OpenKM.");
                return;
            }

            try {
                string rutaOpenkm = getRutaOpenkm();
                string idFolder = TryGetNodeUuid(rutaOpenkm);
                if (string.IsNullOrEmpty(idFolder))
                    return;

                ProcessDocuments(rutaOpenkm, idFolder);
            }
            catch (Exception ex) {
                Log.Error(ex, "Error General");
                ShowError("Error general", ex);
            }
            finally {
                DesconexionOpenKM();
                IniciarProceso.Enabled = true;
            }
            MessageBox.Show("Cargados: " + Cantidad.Text + " Errores: " + Error.Text, "Resultados del proceso");
            Log.Information("Cargados: " + Cantidad.Text + " Errores: " + Error.Text, "Resultados del proceso");
            FinalizeUI();
        }
        private void FinalizeUI()
        {
            Cantidad.Text = "0";
            DirectorioFuentes.Text = "";
            ConError = 0;
            Error.Text = ConError.ToString();
            progressBar1.Value = 0;
            CanProc.Text = "0";
            Instancia.SelectedIndex = -1;
            MetaDato.SelectedIndex = -1;
            MetaDato.Text = "";
            Instancia.Text = "";
            ListaDocumentos.Clear();
        }


        private void ResetUI()
        {
            ConError = 0;
            Error.Text = ConError.ToString();
            progressBar1.Value = 0;
            CanProc.Text = "0";
        }

        private string TryGetNodeUuid(string path)
        {
            try {
                return ws.repository.getNodeUuid(path);
            }
            catch (Exception ex) {
                Log.Error(ex, $"Verificar la ruta de digitalización: {path}");
                ShowError($"Verificar la ruta de digitalización: {path}", ex);
                return null;
            }
        }

        private void ProcessDocuments(string rutaOpenkm, string idFolder)
        {
            foreach (string docPath in ListaDocumentos) {
                FileInfo fileInfo = new FileInfo(docPath);
                string nodePath = rutaOpenkm + fileInfo.Name;
                bool exists = DocumentExists(nodePath);

                if (exists) {
                    MessageBox.Show($"El documento ya existe en la ruta: {nodePath}");
                    UpdateProgress();
                    continue;
                }

                string docId = UploadDocument(idFolder, rutaOpenkm, docPath);
                //MessageBox.Show($"DocUUID: {docId}");
                //Error al cargar

                if (string.IsNullOrEmpty(docId)) {
                    UpdateProgress();
                    continue;
                }
                string cedula = TrimFileName(fileInfo.Name);
                if (!AssignMetadata(docId, cedula)) {
                    MessageBox.Show($"No se logró asignar metadato al documento: {docPath}");
                    try {
                        ws.document.moveDocument(docId, getCarpetaError());
                    }
                    catch (Exception ex4) {
                        Log.Error(ex4, $"No se pudo mover documento {docId}, a {getCarpetaError()}");
                    }

                }
                else {
                    RunWorkFlow(cedula, docId, docPath);
                }

                UpdateProgress();
            }
        }

        private bool DocumentExists(string path)
        {
            try {
                return !string.IsNullOrEmpty(ws.repository.getNodeUuid(path));
            }
            catch {
                return false;
            }
        }

        private string UploadDocument(string idFolder, string rutaOpenkm, string ArchivoOKM)
        {
            try {
                FileInfo fileInfo = new FileInfo(ArchivoOKM);
                byte[] pdfbytes = OptimizePdfImages(fileInfo);

                // Write the optimized PDF bytes to a temporary file
                string tempFilePath = Path.GetTempFileName();
                File.WriteAllBytes(tempFilePath, pdfbytes);

                try {
                    using (var fs = new FileStream(tempFilePath, FileMode.Open, FileAccess.Read)) {
                        var doc = ws.document.createDocument(idFolder, fileInfo.Name, fs);
                        return doc.uuid;
                    }
                }
                finally {
                    // Clean up the temporary file
                    if (File.Exists(tempFilePath))
                        File.Delete(tempFilePath);
                }
            }
            catch (Exception ex) {
                Log.Error(ex, "Error al cargar documento en OpenKM");
                ShowError("Error al cargar documento en OpenKM", ex);
                return null;
            }
        }


        public static byte[] OptimizePdfImages(FileInfo fileInfo, int jpegQuality = 50)
        {
            if (!fileInfo.Exists)
                throw new FileNotFoundException("File does not exist.", fileInfo.FullName);

            if (!fileInfo.Extension.Equals(".pdf", StringComparison.OrdinalIgnoreCase)) {
                // If it's not a PDF, just return the byte array of that file
                return File.ReadAllBytes(fileInfo.FullName);
            }

            string inputPath = fileInfo.FullName;
            if (!File.Exists(inputPath))
                throw new FileNotFoundException("PDF not found", inputPath);

            using (var doc = PdfReader.Open(inputPath, PdfDocumentOpenMode.Modify)) {
                foreach (var page in doc.Pages) {
                    var resources = page.Elements.GetDictionary("/Resources");
                    if (resources == null)
                        continue;

                    var xObjects = resources.Elements.GetDictionary("/XObject");
                    if (xObjects == null)
                        continue;

                    foreach (var element in xObjects.Elements.Values) {
                        if (!(element is PdfReference reference))
                            continue;

                        var xObject = reference.Value as PdfDictionary;
                        if (xObject == null || xObject.Elements.GetString("/Subtype") != "/Image")
                            continue;

                        var colorSpace = xObject.Elements.GetObject("/ColorSpace")?.ToString();
                        var hasMask = xObject.Elements.ContainsKey("/Mask");
                        var bpc = xObject.Elements.ContainsKey("/BitsPerComponent")
                            ? xObject.Elements.GetInteger("/BitsPerComponent")
                            : 8;

                        // Skip risky images
                        if (hasMask || (colorSpace != null && colorSpace.Contains("/Indexed")) || bpc == 1) {
                            Console.WriteLine("Skipping risky image (mask/indexed/BPC=1)");
                            continue;
                        }

                        try {
                            var stream = xObject.Stream;
                            byte[] originalBytes = stream.Value;

                            using (var ms = new MemoryStream(originalBytes))
                            using (var img = Image.FromStream(ms))
                            using (var jpegStream = new MemoryStream()) {
                                var encoder = ImageCodecInfo.GetImageDecoders()
                                    .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
                                var encoderParams = new EncoderParameters(1);
                                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, jpegQuality);

                                img.Save(jpegStream, encoder, encoderParams);
                                byte[] jpegBytes = jpegStream.ToArray();

                                xObject.Stream.Value = jpegBytes;
                                xObject.Elements.SetName("/Filter", "/DCTDecode");
                                xObject.Elements.SetInteger("/Length", jpegBytes.Length);
                                xObject.Elements.SetInteger("/BitsPerComponent", 8);
                                xObject.Elements.SetName("/ColorSpace", "/DeviceRGB");
                            }
                        }
                        catch (Exception ex) {
                            Console.WriteLine("Skipping image due to error: " + ex.Message);
                            continue;
                        }
                    }
                }

                using (var outStream = new MemoryStream()) {
                    doc.Save(outStream, false);
                    return outStream.ToArray();
                }
            }
        }


        private bool AssignMetadata(string idDocOpenKM, string cedula)
        {
            Dictionary<string, string> props = new Dictionary<string, string>();

            try {
                props.Add($"okp:{MetaDato.Text}.{getCampo()}", cedula);
                ws.propertyGroup.addPropertyGroup(idDocOpenKM, $"okg:{MetaDato.Text}", props);               
                return true;
            }
            catch (Exception ex) {
                Log.Error(ex, $"Error al asignar metadatos: {cedula} okp:{MetaDato.Text}.{getCampo()} {cedula}");

                // Try checking if the metadata was actually assigned
                Thread.Sleep(500);
                bool exists = false;
                try {
                    exists = ws.propertyGroup.hasPropertyGroup(idDocOpenKM, $"okg:{MetaDato.Text}");
                }
                catch (Exception ex2) {
                    Log.Error(ex2, $"Error al asignar metadatos: {cedula} okp:{MetaDato.Text}.{getCampo()} {cedula}");
                    MessageBox.Show(
                    $"Error al asignar metadatos: {cedula}\n{ex2.Message}\n\nDetalles:\n{ex2}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );

                }
                return exists;
            }
        }

        public string TrimFileName(string input)
        {
            // Remove ".pdf" extension if present (case-insensitive)
            if (input.EndsWith(".pdf", StringComparison.OrdinalIgnoreCase)) {
                input = input.Substring(0, input.Length - 4);
            }

            // Find the last occurrence of '('
            int parenIndex = input.LastIndexOf('(');
            if (parenIndex > 0) {
                // Remove everything from the last '(' (and before) to the end
                return input.Substring(0, parenIndex).TrimEnd();
            }

            return input;
        }

        private void CardPanel_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(Color.FromArgb(226, 229, 234))) {
                Rectangle rect = ((Control)sender).ClientRectangle;
                rect.Width -= 1;
                rect.Height -= 1;
                e.Graphics.DrawRectangle(pen, rect);
            }
        }

        private void UpdateProgress()
        {
            progressBar1.Increment(1);
            CanProc.Text = progressBar1.Value.ToString();
            Refresh();
        }

        private void ShowError(string message, Exception ex)
        {
            MessageBox.Show($"{message}\n{ex.Message}\n\nDetalles:\n{ex}",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }

        public bool ConexionOpenKM()
        {
            ws = OKMWebservicesFactory.newInstance(host);
            try {
                username = Usuario.Text;
                password = Clave.Text;
                ws.login(username, password);
                Log.Information("Connected to OpenKm");
                return true;
            }
            catch (Exception ex) {
                Log.Error(ex, $"No se pudo conectar a OpenKm {host}");
                return false;
            }
        }

        public bool DesconexionOpenKM()
        {
            try {
                ws.logout();
                return true;
            }
            catch (Exception ex) {
                Log.Error(ex, "No se pudo descoenctar Okm");
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        private void SeleccionarRuta_Click(object sender, EventArgs e)
        {
            try {
                int CantArch = 0;
                DialogoFolder.ShowNewFolderButton = false;
                DialogoFolder.RootFolder = Environment.SpecialFolder.MyComputer;
                DialogResult result = DialogoFolder.ShowDialog();
                if (result == DialogResult.OK) {
                    string foldername = DialogoFolder.SelectedPath;
                    string[] files = Directory.GetFiles(foldername);
                    foreach (string f in files) {
                        ListaDocumentos.Add(f);
                        CantArch++;
                    }
                    Cantidad.Text = CantArch.ToString();
                    DirectorioFuentes.Text = foldername;
                    progressBar1.Maximum = CantArch;
                }
            }
            catch (Exception ex) {
                Log.Error(ex, "Error al seleccionar ruta");
                MessageBox.Show(ex.Message);
            }
        }

        private void Instancia_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetaDato.Items.Clear();
            MetaDato.SelectedIndex = -1;

            //Cedulacion
            if (Instancia.SelectedIndex == 0) {
                MetaDato.Items.Add("CED_SOLICITUD_CEDULAS");
                MetaDato.Items.Add("EXPEDIENTE_DE_EXTRAJEROS");
                MetaDato.Items.Add("CED_POSITIVOS");
            }
            //RC
            else if (Instancia.SelectedIndex == 1) {
                MetaDato.Items.Add("RC_NA_RESOLUCIONES");
                MetaDato.Items.Add("RC_NA_PARTES_CLINICOS");
                MetaDato.Items.Add("RC_NA_INSCRIPCIONES");
                MetaDato.Items.Add("RC_NA_BAUTIMOS");
                MetaDato.Items.Add("RC_NA_ANOTACIONES");
                MetaDato.Items.Add("RC_MA_RESOLUCIONES");
                MetaDato.Items.Add("RC_MA_INSCRIPCIONES");
                MetaDato.Items.Add("RC_MA_ANOTACIONES");
                MetaDato.Items.Add("RC_DE_RESOLUCIONES");
                MetaDato.Items.Add("RC_DE_INSCRIPCIONES");
                MetaDato.Items.Add("RC_DE_ANOTACIONES");
                MetaDato.Items.Add("RC_ADOPCIONES");
                MetaDato.Items.Add("RC_CERTIFICACIONES");
            }
            //OE
            else {
                MetaDato.Items.Add("OE_TER");
                MetaDato.Items.Add("OE_PADRONES");
                MetaDato.Items.Add("OE_CAMBIOS_RESIDENCIA");
                MetaDato.Items.Add("OE_ACTA_MESA");
                MetaDato.Items.Add("OE_ACTA_JUNTA_REPRESENTANTE");
                MetaDato.Items.Add("OE_ACTA_JUNTA_PRESIDENTE");
                MetaDato.Items.Add("OE_ACTA_JUNTA_DIPUTADO");
                MetaDato.Items.Add("OE_ACTA_JUNTA_CIRCUITAL");
                MetaDato.Items.Add("OE_ACTA_JUNTA_ALCALDE");
                MetaDato.Items.Add("AH_MATRIMONIOS");
                MetaDato.Items.Add("AH_DEFUNCIONES");
                MetaDato.Items.Add("AH_BAUTIMOS");
                MetaDato.Items.Add("OE_RENUNCIA_PARTIDOS");
                MetaDato.Items.Add("OE_INSCRIPCION_PARTIDOS");
                MetaDato.Items.Add("OE_ACTA_JUNTA_CONCEJAL");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MetaDato.Items.Clear();
            Instancia.SelectedIndex = -1;
            MetaDato.SelectedIndex = -1;
        }


    }
}
