using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace send_email_gmail_smtp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            var client = new SmtpClient("smtp.gmail.com", 587)
            {
                UseDefaultCredentials = false,
                EnableSsl = true,
                // create a gamail, and then go to this url https://www.google.com/settings/u/1/security/lesssecureapps
                // and Allow less secure apps: ON
                //Credentials = new NetworkCredential("tagayat21@gmail.com", "Tagayat@2021")
                //Credentials = new NetworkCredential("ahsnayat21@gmail.com", "ahsnayat@2021")
                //Credentials = new NetworkCredential("dina.ayatqurancenter@gmail.com", "ayatqurancenter2021")
                ////Credentials = new NetworkCredential("ahsanseven02@gmail.com", "Ahsan7777")
                //Credentials = new NetworkCredential("eshrafayat@gmail.com", "Ayat12345")
                //Credentials = new NetworkCredential("Ayatcenter111@gmail.com", "Ayat12345")
                //Credentials = new NetworkCredential("Ayateshraf@gmail.com", "Ayat12345")
                Credentials = new NetworkCredential("Ahsanhadeth111@gmail.com", "Ayat12345")
                //Credentials = new NetworkCredential("ishraf.ayatcenter@gmail.com", "$?*ad21miN++")
            };

            //            string emails = @"ahmaag951@gmail.com,
            //n.shaysh@gmail.com,
            //amiradawwam@yahoo.com";

            string emails = @"jkhaled788@gmail.com,
adelgehad167@gmail.com,
gabuelkassem33@gmail.com,
gogo71975@gmail.com,
halaabd372@gmail.com,
ayamohameda880@gmail.com,
hanan_adel23@yahoo.com,
hananshafey1970@gmail.com,
hanan.amer.cs@gmail.com,
khadijakhamis476@gmail.com,
kholoud-refaat@hotmail.com,
daniaali15588.da@gmail.com,
samaeid334@gmail.com,
doaaalaaza@yahoo.com,
dodydad1983@gmail.com,
dina_m1969@hotmail.com,
raniahamza82@gmail.com,
omarsalma201130@gmail.com,
rehabmohamed-74@hotmail.com,
eng.raghdamoustafa84@gmail.com,
rihamalrawi89@gmail.com,
reemadamomer@gmail.com,
sara98.ezzat@gmail.com,
Sbdr70487@gmail.com,
salma157450@gmail.com,
salwamoaz5@gmail.com,
samaayehia99@gmail.com,
om_omar_bokra@yahoo.com,
smsmyoyo2012@gmail.com,
samaryousryden85@gmail.com,
Samira.naitiaz@gmail.com,
sondos.menged@outlook.it
sohirmoneim@yahoo.com,
mshrook12@gmail.com,
drshosho227@yahoo.com,
shimo.shaker@yahoo.com,
shemoayman316@gmail.com,
ayeshafouadster@gmail.com,
om.amaar.am@gmail.com,
3zzaallam@gmail.com,
Azzaelhosary55@gmail.com,
alaali79@yahoo.com,
aliaanabieh@gmail.com,
aliaa.ali.hassan.2019@gmail.com,
youmna.abdullah@pepsico.com,
fatmahegazi324@gmail.com,
omiyasfatima@gmail.com,
omymna94@gmail.com,
tamtamtota919@gmail.com,
imustafa312@gamil.com,
arwadaid@gmail.com,
fb8074122@gmail.com,
hodahesham1998@gmail.com,
alaouisawsan4@gmail.com,
lamiaelgendy@hotmail.com,
lamiaaborahma@gmail.com,
marwabassam@gmail.com,
marwaabdelmoaty2000@gmail.com,
marwamsalah@gmail.com,
omhamzademaali1451@gmail.com,
rofyandtomy6@gmail.com,
mohamed.hesien@te.eg
omhani1962@gmail.com,
manaratef2022@gmail.com,
Manalsedki_1992@yahoo.com,
manalsadek@gmail.com,
mennakhaled489@gmail.com,
menna15nawar@gmail.com,
Mennayahia15@yahoo.com,
s38071195@gmail.com,
mannonamodather@yahoo.com,
mayalaa1985@yahoo.com,
maisoun.sonsona@gmail.com,
ramashkha.93.m.a@gmail.com,
nagwazoma@gmail.com,
nagwa1632010@gmail.com,
ng157989@gmail.com,
nashwa.elaraby2014@gmail.com,
na3omg2015@gmail.com,
khamlichinaima7@gmail.com,
naghamnomar@gmail.com,
y888877776@gmail.com,
nbishr@gmail.com,
nouranamr9014@gmail.com,
nermeenyosry74@gmail.com,
hagaralboraey@gamil.com,
h.haroon21392@gmail.com,
hebafathi536@yahoo.com,
Huda.kandal@mail.com,
hadeermohammed024@gmail.com,
dorydora2011@gmail.com,
wild7bird5h@gmail.com,
wardaallam963@gmail.com,
yasmeensh89@hotmail.com,
bonitadia1111@gmail.com,
basetasmaa2015@gmail.com,
hamadaasmaa169@gmail.com,
zahrashawky224@gmail.com,
zahraanonym@yahoo.com,
shimaamenem3@gmail.com";



            var mailMessage = new MailMessage
            {
                From = new MailAddress("admin@ayatqurancenter.com"),
                Subject = "برنامج أحسن الحديث",
                Body = @"<p>﴿اللَّهُ نَزَّلَ أَحْسَنَ الْحَدِيثِ كِتَابًا مُّتَشَابِهًا مَّثَانِيَ تَقْشَعِرُّ مِنْهُ جُلُودُ الَّذِينَ يَخْشَوْنَ رَبَّهُمْ ثُمَّ تَلِينُ جُلُودُهُمْ وَقُلُوبُهُمْ إِلَىٰ ذِكْرِ اللَّهِ ۚ ذَٰلِكَ هُدَى اللَّهِ يَهْدِي بِهِ مَن يَشَاءُ ۚ وَمَن يُضْلِلِ اللَّهُ فَمَا لَهُ مِنْ هَادٍ﴾ [الزمر ٢٣].</p>
<p>هيا ننطلق في رحلة برنامج أحسن الحديث بدفعته السابعة نطبق عمليًا ما تم دراسته في برنامج تاج الكرامة، ننهل فيه من علوم القرآن وتدبره ما يروي قلوبنا الظمأى لمعرفة مراد ربها من آيات القرآن الكريم.</p>
<p>▪️للتسجيل في البرنامج يرجى ملئ الاستمارة المرفقة:</p>
<p>▫️استمارة النساء: <br />https://forms.gle/TS9F8ypLUsqarGLu5</p>
<p>▫️استمارة الرجال:<br />https://forms.gle/sirZ1Vxv5ZmFwVjR8</p>
<p>▫️للاستفسار عن التسجيل بالبرنامج:<br />https://t.me/questions_a7san_bot</p>
<p>▪️ملحوظات هامة:</p>
<p>1. التسجيل لخريجي برنامج تاج الكرامة.</p>
<p>2. عدم نشر رابط استمارة التسجيل أو جروب البرنامج.</p>
<p>3. يرجى عدم مغادرة الاستمارة قبل التأكد من الانضمام لجروب البرنامج على التليجرام.<br />-ستجدون رابط الجروب في نهاية الاستمارة.</p>
<p>4. يرجى العلم بأن الاستمارة بها أسئلة على:</p>
<p>أول ثلاثة فصول من كتاب الطريق إلى القرآن للشيخ إبراهيم السكران.<br />https://drive.google.com/file/d/1HB1y8yyuik8NX9npvVs7ahFBuFuHhpwA/view?usp=sharing</p>
<p>لقاء معراج الحفظة للشيخ محمد خيري.<br />https://soundcloud.com/msjdaboahmed/vsssl9kqezz9</p>
<p>▪️قيمة الاشتراك بالبرنامج 300 جنية.</p>
<p>💌 بشرى باستثناء غير المقتدرين من سداد قيمة الاشتراك.</p>",
                IsBodyHtml = true
            };

            var multi = emails.Split(',');
            string wrong = "";
            //foreach (var email in multi)
            //{
            //    mailMessage.To.Add(new MailAddress(email));
            //}

            for (int i = 0; i < multi.Length; i++)
            {
                try
                {
                    mailMessage.To.Add(new MailAddress(multi[i]));
                }
                catch (Exception)
                {
                    wrong += multi[i] + "---";
                    continue;
                }
            }

            //client.Send("ahmaag951@gmail.com", "ahmaag951@gmail.com", "test subject", "test body");
            if (mailMessage.To.Count <= 100)
            {
                client.Send(mailMessage);

            }
            else
            {
                throw new Exception();
            }

            return "Sent";
        }

        public static void SendMultiEmail(string emails, string subj, string message)
        {
            //get from app setting
            var host = "";
            var fromEmail = "";
            var pass = "";
            var enableSsl = true;
            var port = "587";
            // end
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subj,
                Body = message,
                IsBodyHtml = true
            };

            var multi = emails.Split(',');
            foreach (var email in multi)
            {
                mailMessage.To.Add(new MailAddress(email));
            }

            var smtp = new System.Net.Mail.SmtpClient { Host = host, EnableSsl = enableSsl };
            var networkCredential = new NetworkCredential { UserName = mailMessage.From.Address, Password = pass };
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = networkCredential;
            smtp.Port = int.Parse(port);
            smtp.Send(mailMessage);
        }

    }
}
