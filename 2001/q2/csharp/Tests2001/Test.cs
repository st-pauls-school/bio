using NUnit.Framework;
using System;

namespace Tests2001
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void TestCase()
		{
			var q2 = new BIO2001.Question2("Informatics", "Olympiad");

			Assert.AreEqual("I N F O R M A T C S B D E G H J K L P U V W X Y Z", q2.Left);
			Assert.AreEqual("Z X W V U T S R N K J H G F E C B D A I P M Y L O", q2.Right);

			Assert.AreEqual("SN", q2.ChangeABigram('C', 'R', true));
			Assert.AreEqual("HK", q2.ChangeABigram('S', 'E', true));

			Assert.AreEqual("CR", q2.ChangeABigram('S', 'N', false));
			Assert.AreEqual("SE", q2.ChangeABigram('H', 'K', false));

			Assert.AreEqual("HKSNTJ", q2.Encrypt("SECRET"));
			Assert.AreEqual("BJXARW", q2.Encrypt("HELLO"));
			Assert.AreEqual("HELLO", q2.Decrypt("BJXARW"));
		}

		[Test()]
		public void GivenCase()
		{
			var q2 = new BIO2001.Question2("Romulus", "Remus");

			Assert.AreEqual("R O M U L S A B C D E F G H I J K N P T V W X Y Z", q2.Left);

			Assert.AreEqual("Z Y X W V T P O N L K J I H G F D C B A S U M E R", q2.Right);

			Assert.AreEqual("CA", q2.ChangeABigram('P', 'L', true));

			Assert.AreEqual("CAOPKGZG", q2.Encrypt("PLAYFAIR"));
			Assert.AreEqual("GRIDS", q2.Decrypt("XGTJRO"));
		}

		[Test]
		public void Test1()
		{
			var t1 = new BIO2001.Question2("Dog", "Bone");

			Assert.AreEqual("D O G A B C E F H I J K L M N P R S T U V W X Y Z", t1.Left);
			Assert.AreEqual("Z Y X W V U T S R P M L K J I H G F D C A E N O B", t1.Right);

			Assert.AreEqual("WLZKKT", t1.Encrypt("KENNEL"));
			Assert.AreEqual("VUAF", t1.Encrypt("CAT"));
			Assert.AreEqual("BIRD", t1.Decrypt("NVSC"));
			Assert.AreEqual("MOUSE", t1.Decrypt("YJIFOS"));
		}

		[Test]
		public void Test2()
		{
			var t2 = new BIO2001.Question2("Apricot", "Orange");

			Assert.AreEqual("A P R I C O T B D E F G H J K L M N S U V W X Y Z", t2.Left);
			Assert.AreEqual("Z Y X W V U T S P M L K J I H F D C B E G N A R O", t2.Right);

			Assert.AreEqual("MFWERC", t2.Encrypt("LEMON"));
			Assert.AreEqual("EZEZNEZP", t2.Encrypt("CUCUMBER"));
			Assert.AreEqual("BANANA", t2.Decrypt("XSXCXC"));
			Assert.AreEqual("LEMON", t2.Decrypt("MFWERC"));
		}

		[Test]
		public void Test3()
		{
			var t3 = new BIO2001.Question2("ABRACADABRA", "XYZZY");

			Assert.AreEqual("A B R C D E F G H I J K L M N O P S T U V W X Y Z", t3.Left);
			Assert.AreEqual("W V U T S R P O N M L K J I H G F E D C B A Z Y X", t3.Right);

			Assert.AreEqual("HUGTOGEFZP", t3.Encrypt("CORNUCOPIA"));
			Assert.AreEqual("MHFWEWZB", t3.Encrypt("LIBRARY"));
			Assert.AreEqual("AMENDS", t3.Decrypt("ESFMAW"));
			Assert.AreEqual("PELICAN", t3.Decrypt("SDMHYVZH"));
		}

		[Test]
		public void Test4()
		{
			var t4 = new BIO2001.Question2("ABCDEFGHIJKLMNOPRSTUVWXYZ", "ZYXWVUTSRPONMLKJIHGFEDCBA");

			Assert.AreEqual("A B C D E F G H I J K L M N O P R S T U V W X Y Z", t4.Left);
			Assert.AreEqual("A B C D E F G H I J K L M N O P R S T U V W X Y Z", t4.Right);

			Assert.AreEqual("KRVDAFTG", t4.Encrypt("PLAYFAIR"));
			Assert.AreEqual("CIPHER", t4.Decrypt("HDFSUB"));
		}




	}
}
