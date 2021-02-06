using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class BundleDrugs
    {
        public Drug Acid = new Drug();
        public Drug Cocaine = new Drug();
        public Drug Crack = new Drug();
        public Drug CrystalMeth = new Drug();
        public Drug Ecstasy = new Drug();
        public Drug Hash = new Drug();
        public Drug Heroin = new Drug();
        public Drug Mescaline = new Drug();
        public Drug Morphine = new Drug();
        public Drug Mushrooms = new Drug();
        public Drug Weed = new Drug();

        public BundleDrugs()
        {
            Acid.TypeOfDrug = DrugType.ACID;
            Cocaine.TypeOfDrug = DrugType.COCAINE;
            Crack.TypeOfDrug = DrugType.CRACK;
            CrystalMeth.TypeOfDrug = DrugType.CRYSTAL_METH;
            Ecstasy.TypeOfDrug = DrugType.ECSTASY;
            Hash.TypeOfDrug = DrugType.HASH;
            Heroin.TypeOfDrug = DrugType.HEROIN;
            Mescaline.TypeOfDrug = DrugType.MESCALINE;
            Morphine.TypeOfDrug = DrugType.MORPHINE;
            Mushrooms.TypeOfDrug = DrugType.MUSHROOMS;
            Weed.TypeOfDrug = DrugType.WEED;
        }

        public void generatePrices()
        {
            Acid.generateNewPrice();
            Cocaine.generateNewPrice();
            Crack.generateNewPrice();
            CrystalMeth.generateNewPrice();
            Ecstasy.generateNewPrice();
            Hash.generateNewPrice();
            Heroin.generateNewPrice();
            Mescaline.generateNewPrice();
            Morphine.generateNewPrice();
            Mushrooms.generateNewPrice();
            Weed.generateNewPrice();
        }

        public void generateAmounts()
        {
            Acid.generateNewQuantity();
            Cocaine.generateNewQuantity();
            Crack.generateNewQuantity();
            CrystalMeth.generateNewQuantity();
            Ecstasy.generateNewQuantity();
            Hash.generateNewQuantity();
            Heroin.generateNewQuantity();
            Mescaline.generateNewQuantity();
            Morphine.generateNewQuantity();
            Mushrooms.generateNewQuantity();
            Weed.generateNewQuantity();
        }
    }
}
