using NHibernate;
using NUnit.Framework;

using System.Collections.Generic;

using MeaData;

namespace MeaDataTest {

    [TestFixture]
    public class TissueTypeFixture : BaseTestFixture {

        [Test]
        public void CanReadTissueTypes() {
            // Assert that TissueTypes can be read from the database
            int count = _sess.QueryOver<TissueType>().RowCount();
            Assert.Greater(count, 1);
        }

        [Test]
        public void CanGetTissueTypeChildren() {
            // Select the Entity
            TissueType forebrain = _sess.QueryOver<TissueType>()
                                      .WhereRestrictionOn(tt => tt.Name).IsLike("%Prosencephalon%")
                                      .SingleOrDefault();
            Assert.NotNull(forebrain);

            // Select its children
            Assert.Greater(forebrain.Children.Count, 1);
        }

        [Test]
        public void CanGetTissueTypeParent() {
            // Select the Entity
            TissueType forebrain = _sess.QueryOver<TissueType>()
                                      .WhereRestrictionOn(tt => tt.Name).IsLike("%Prosencephalon%")
                                      .SingleOrDefault();
            Assert.NotNull(forebrain);

            // Select its parent
            Assert.NotNull(forebrain.Parent);
        }

        [Test]
        public void CanGetTopLevelTissueTypes() {
            // Select top-level Entities from the database (ones with no parent)
            IList<TissueType> entities = _sess.QueryOver<TissueType>()
                                            .Where(tt => tt.Parent == null)
                                            .OrderBy(tt => tt.Name).Asc
                                            .List();
            Assert.Greater(entities.Count, 0);

            // Assert that each one has children but no parents
            foreach (TissueType tt in entities) {
                Assert.Null(tt.Parent);
                Assert.Greater(tt.Children.Count, 0);
            }
        }

        [Test]
        public void CanCloneTissueType() {
            // Select an Entity and clone it
            TissueType forebrain = _sess.QueryOver<TissueType>()
                                      .WhereRestrictionOn(tt => tt.Name).IsLike("%Prosencephalon%")
                                      .SingleOrDefault();
            TissueType clone = forebrain.Clone() as TissueType;

            // Assert that the Entities have the same values...
            Assert.AreEqual(forebrain.Name, clone.Name);
            Assert.AreEqual(forebrain.IsSelectable, clone.IsSelectable);
            Assert.AreEqual(forebrain.Comments, clone.Comments);
            Assert.AreEqual(forebrain.Children.Count, clone.Children.Count);
            Assert.NotNull(clone.Parent);
            Assert.AreNotSame(forebrain.Parent, clone.Parent);

            // ...but are different references
            Assert.AreNotSame(forebrain, clone);

            // Assert that the clone gets a different Guid when persisted
            cloneAsserts(forebrain, clone);
        }

        [Test]
        public void CanCreateAllTissueTypes() {
            // Create all transient TissueType objects
            IList<TissueType> tissueTypes = createTissueTypes();
            
            // Connect to the meadata database
            Util.DbWrapper dbw = new Util.DbWrapper(
                typeof(Entity).Assembly,
                "meadata",
                Util.Properties.Resources.MeaDataDbVersion,
                Util.Properties.Resources.MeaData);

            // Replace all TissueTypes records in this database with the transient objects just created
            using (ISession tempSess = dbw.OpenSession()) {
                using (ITransaction trans = tempSess.BeginTransaction()) {
                    tempSess.CreateSQLQuery("DELETE FROM tissue_types").ExecuteUpdate();
                    foreach (TissueType tt in tissueTypes)
                        tempSess.Save(tt);
                    trans.Commit();
                }
            }
        }
        private IList<TissueType> createTissueTypes() {
            // Create transient TissueType objects
            TissueType brain = new TissueType() { Name = "Brain", IsSelectable = false, Parent = null };
            TissueType hindbrain = new TissueType() { Name = "Hindbrain (rhombencephalon)", IsSelectable = false };

            TissueType myelenceph = new TissueType() { Name = "Myelencephalon", IsSelectable = false };
            TissueType medulla = new TissueType() { Name = "Medulla oblongata", IsSelectable = true };
            TissueType medulPyrs = new TissueType() { Name = "Medullary pyramids", IsSelectable = true };
            TissueType respirCenter = new TissueType() { Name = "Respiratory center", IsSelectable = true };
            TissueType olivary = new TissueType() { Name = "Olivary body", IsSelectable = true };
            TissueType infOlivNuc = new TissueType() { Name = "Inferior olivary nucleus", IsSelectable = true };
            TissueType medulNucs = new TissueType() { Name = "Medullary cranial nerve nuclei", IsSelectable = false };
            TissueType infSalivNuc = new TissueType() { Name = "Inferior salivatory nucleus", IsSelectable = true };
            TissueType nucAmbig = new TissueType() { Name = "Nucleus ambiguus", IsSelectable = true };
            TissueType dorsVagusNuc = new TissueType() { Name = "Dorsal nucleus of vagus nerve", IsSelectable = true };
            TissueType hypoGlossNuc = new TissueType() { Name = "Hypoglossal nucleus", IsSelectable = true };
            TissueType solitaryNuc = new TissueType() { Name = "Solitary nucleus", IsSelectable = true };

            TissueType metenceph = new TissueType() { Name = "Metencephalon", IsSelectable = false };
            TissueType pons = new TissueType() { Name = "Pons", IsSelectable = true };
            TissueType pontineNucs = new TissueType() { Name = "Pontine cranial nerve nuclei", IsSelectable = false };
            TissueType trigeminalSensNuc = new TissueType() { Name = "Sensory nucleus of trigeminal nerve (V)", IsSelectable = true };
            TissueType trigeminalMotorNuc = new TissueType() { Name = "Motor nucleus of trigeminal nerve (V)", IsSelectable = true };
            TissueType abducensNuc = new TissueType() { Name = "Abducens nucleus (VI)", IsSelectable = true };
            TissueType facialNuc = new TissueType() { Name = "Facial nerve nucleus (VII)", IsSelectable = true };
            TissueType vestibuloCochNuc = new TissueType() { Name = "Vestibulocochlear nuclei (VIII)", IsSelectable = true };
            TissueType supSalivNuc = new TissueType() { Name = "Superior salivatory nucleus", IsSelectable = true };
            TissueType ponTegmentum = new TissueType() { Name = "Pontine tegmentum", IsSelectable = true };
            TissueType respirCenters = new TissueType() { Name = "Respiratory centers", IsSelectable = false };
            TissueType pneumoCenter = new TissueType() { Name = "Pneumotaxic center", IsSelectable = true };
            TissueType apneusticCenter = new TissueType() { Name = "Apneustic center", IsSelectable = true };
            TissueType locusCoeruleus = new TissueType() { Name = "Locus coeruleus", IsSelectable = true };
            TissueType peduncPonNuc = new TissueType() { Name = "Pedunculopontine nucleus", IsSelectable = true };
            TissueType ponLatTegmentNuc = new TissueType() { Name = "Laterodorsal tegmental nucleus", IsSelectable = true };
            TissueType ponReticTegmentNuc = new TissueType() { Name = "Tegmental pontine reticular nucleus", IsSelectable = true };
            TissueType supOlivComplex = new TissueType() { Name = "Superior olivary complex", IsSelectable = true };
            TissueType ponsReticForm = new TissueType() { Name = "Paramedian pontine reticular formation", IsSelectable = true };
            TissueType cerebelPeduncs = new TissueType() { Name = "Cerebellar peduncles", IsSelectable = false };
            TissueType supCerebelPedunc = new TissueType() { Name = "Superior cerebellar peduncle", IsSelectable = true };
            TissueType midCerebelPedunc = new TissueType() { Name = "Middle cerebellar peduncle", IsSelectable = true };
            TissueType infCerebelPedunc = new TissueType() { Name = "Inferior cerebellar peduncle", IsSelectable = true };
            TissueType cerebellum = new TissueType() { Name = "Cerebellum", IsSelectable = true };
            TissueType cerebelVermis = new TissueType() { Name = "Cerebellar vermis", IsSelectable = true };
            TissueType cerebelHemis = new TissueType() { Name = "Cerebellar hemispheres", IsSelectable = false };
            TissueType cerebelAntLobe = new TissueType() { Name = "Anterior lobe", IsSelectable = true };
            TissueType cerebelPostLobe = new TissueType() { Name = "Posterior lobe", IsSelectable = true };
            TissueType cerebelFloccLobe = new TissueType() { Name = "Flocculonodular lobe", IsSelectable = true };
            TissueType cerebelNucs = new TissueType() { Name = "Cerebellar nuclei", IsSelectable = false };
            TissueType fastigNuc = new TissueType() { Name = "Fastigial nucleus", IsSelectable = true };
            TissueType globNuc = new TissueType() { Name = "Globose nucleus", IsSelectable = true };
            TissueType embolNuc = new TissueType() { Name = "Emboliform nucleus", IsSelectable = true };
            TissueType dentNuc = new TissueType() { Name = "Dentate nucleus", IsSelectable = true };

            TissueType midbrain = new TissueType() { Name = "Midbrain (mesencephalon)", IsSelectable = false };
            TissueType tectum = new TissueType() { Name = "Tectum", IsSelectable = true };
            TissueType corpQuad = new TissueType() { Name = "Corpora quadrigemina", IsSelectable = true };
            TissueType supCollic = new TissueType() { Name = "Superior colliculi", IsSelectable = true };
            TissueType infCollic = new TissueType() { Name = "Inferior colliculi", IsSelectable = true };
            TissueType pretectum = new TissueType() { Name = "Pretectum", IsSelectable = true };
            TissueType cerebPedunc = new TissueType() { Name = "Cerebral peduncle", IsSelectable = true };
            TissueType tegmentum = new TissueType() { Name = "Tegmentum", IsSelectable = true };
            TissueType ventTegmentArea = new TissueType() { Name = "Ventral tegmental area", IsSelectable = true };
            TissueType redNuc = new TissueType() { Name = "Red nucleus", IsSelectable = true };
            TissueType midReticForm = new TissueType() { Name = "Midbrain reticular formation", IsSelectable = true };
            TissueType periAqueGray = new TissueType() { Name = "Periaqueductal gray", IsSelectable = true };
            TissueType subNigra = new TissueType() { Name = "Substantia nigra", IsSelectable = true };
            TissueType parsCompact = new TissueType() { Name = "Pars compacta", IsSelectable = true };
            TissueType parsRetic = new TissueType() { Name = "Pars reticulata", IsSelectable = true };
            TissueType crusCereb = new TissueType() { Name = "Crus cerebri", IsSelectable = true };
            TissueType interPeduncNuc = new TissueType() { Name = "Interpeduncular nucleus", IsSelectable = true };
            TissueType mesCranialNucs = new TissueType() { Name = "Mesencephalic cranial nerve nuclei", IsSelectable = false };
            TissueType oculomotorNuc = new TissueType() { Name = "Oculomotor nucleus (III)", IsSelectable = true };
            TissueType trochNuc = new TissueType() { Name = "Trochlear nucleus (IV)", IsSelectable = true };

            TissueType forebrain = new TissueType() { Name = "Forebrain (prosencephalon)", IsSelectable = false };
            TissueType dienceph = new TissueType() { Name = "Diencephalon", IsSelectable = false };
            TissueType epithal = new TissueType() { Name = "Epithalamus", IsSelectable = true };
            TissueType pineal = new TissueType() { Name = "Pineal body", IsSelectable = true };
            TissueType habenNuc = new TissueType() { Name = "Habenular nuclei", IsSelectable = true };
            TissueType striaMedul = new TissueType() { Name = "Stria medullares", IsSelectable = true };
            TissueType taenThal = new TissueType() { Name = "Taenia thalami", IsSelectable = true };
            TissueType thalamus = new TissueType() { Name = "Thalamus", IsSelectable = true };
            TissueType thalAntNucs = new TissueType() { Name = "Anterior nuclear group", IsSelectable = false };
            TissueType thalAntVentNuc = new TissueType() { Name = "Anteroventral nucleus", IsSelectable = true };
            TissueType thalAntDorsNuc = new TissueType() { Name = "Anterodorsal nucleus", IsSelectable = true };
            TissueType thalAntMedNuc = new TissueType() { Name = "Anteromedial nucleus", IsSelectable = true };
            TissueType thalMedNucs = new TissueType() { Name = "Medial nuclear group", IsSelectable = false };
            TissueType thalMedDorsNuc = new TissueType() { Name = "Medial dorsal nucleus", IsSelectable = true };
            TissueType thalMidNucs = new TissueType() { Name = "Midline nuclear group", IsSelectable = false };
            TissueType paratenNuc = new TissueType() { Name = "Paratenial nucleus", IsSelectable = true };
            TissueType reuniensNuc = new TissueType() { Name = "Reuniens nucleus", IsSelectable = true };
            TissueType rhomboNuc = new TissueType() { Name = "Rhomboidal nucleus", IsSelectable = true };
            TissueType subFascNuc = new TissueType() { Name = "Subfascicular nucleus", IsSelectable = true };
            TissueType intralamNucs = new TissueType() { Name = "Intralaminar nuclear group", IsSelectable = false };
            TissueType thalCentMedNuc = new TissueType() { Name = "Centromedial nucleus", IsSelectable = true };
            TissueType paraFascNuc = new TissueType() { Name = "Parafascicular nucleus", IsSelectable = true };
            TissueType paraCentNuc = new TissueType() { Name = "Paracentral nucleus", IsSelectable = true };
            TissueType centLatNuc = new TissueType() { Name = "Central lateral nucleus", IsSelectable = true };
            TissueType centMedNuc = new TissueType() { Name = "Central medial nucleus", IsSelectable = true };
            TissueType thalLatNucs = new TissueType() { Name = "Lateral nuclear group", IsSelectable = false };
            TissueType thalLatDorsNuc = new TissueType() { Name = "Lateral dorsal nucleus", IsSelectable = true };
            TissueType thalLatPostNuc = new TissueType() { Name = "Lateral posterior nucleus", IsSelectable = true };
            TissueType pulvinar = new TissueType() { Name = "Pulvinar", IsSelectable = true };
            TissueType thalVentNucs = new TissueType() { Name = "Ventral nuclear group", IsSelectable = false };
            TissueType thalVentAntNuc = new TissueType() { Name = "Ventral anterior nucleus", IsSelectable = true };
            TissueType thalVentLatNuc = new TissueType() { Name = "Ventral lateral nucleus", IsSelectable = true };
            TissueType thalVentPostLatNuc = new TissueType() { Name = "Ventral posterior lateral nucleus", IsSelectable = true };
            TissueType thalVentPostMedNuc = new TissueType() { Name = "Ventral posterior medial nucleus", IsSelectable = true };
            TissueType metathal = new TissueType() { Name = "Metathalamus", IsSelectable = true };
            TissueType medGenic = new TissueType() { Name = "Medial geniculate body", IsSelectable = true };
            TissueType latGenic = new TissueType() { Name = "Lateral geniculate body", IsSelectable = true };
            TissueType thalReticNuc = new TissueType() { Name = "Thalamic reticular nucleus", IsSelectable = true };
            TissueType hypothal = new TissueType() { Name = "Hypothalamus", IsSelectable = true };
            TissueType antHypothal = new TissueType() { Name = "Anterior", IsSelectable = false };
            TissueType medPreOptNuc = new TissueType() { Name = "Medial preoptic nucleus", IsSelectable = true };
            TissueType supraChiasNuc = new TissueType() { Name = "Suprachiasmatic nucleus", IsSelectable = true };
            TissueType paraVentricNuc = new TissueType() { Name = "Paraventricular nucleus", IsSelectable = true };
            TissueType supraOptNuc = new TissueType() { Name = "Supraoptic nucleus", IsSelectable = true };
            TissueType antHypothalNuc = new TissueType() { Name = "Anterior hypothalamic nucleus", IsSelectable = true };
            TissueType latPreOptNuc = new TissueType() { Name = "Lateral preoptic nucleus", IsSelectable = true };
            TissueType midPreOptNuc = new TissueType() { Name = "Median preoptic nucleus", IsSelectable = true };
            TissueType periVentPreOptNuc = new TissueType() { Name = "Periventricular preoptic nucleus", IsSelectable = true };
            TissueType hypothalLatNuc = new TissueType() { Name = "Lateral nucleus", IsSelectable = true };
            TissueType tubHypothal = new TissueType() { Name = "Tuberal", IsSelectable = false };
            TissueType hypothalDorsMedNuc = new TissueType() { Name = "Dorsomedial hypothalamic nucleus", IsSelectable = true };
            TissueType hypothalVentMedNuc = new TissueType() { Name = "Ventromedial nucleus", IsSelectable = true };
            TissueType arcuateNuc = new TissueType() { Name = "Arcuate nucleus", IsSelectable = true };
            TissueType latTubNucs = new TissueType() { Name = "Lateral tuberal nuclei", IsSelectable = true };
            TissueType postHypothal = new TissueType() { Name = "Posterior", IsSelectable = false };
            TissueType hypothalPostNuc = new TissueType() { Name = "Posterior nucleus", IsSelectable = true };
            TissueType opticChias = new TissueType() { Name = "Optic chiasm", IsSelectable = true };
            TissueType subFornOrgan = new TissueType() { Name = "Subfornical organ", IsSelectable = true };
            TissueType periVentricNuc = new TissueType() { Name = "Periventricular nucleus", IsSelectable = true };
            TissueType pituitaryStalk = new TissueType() { Name = "Pituitary stalk", IsSelectable = true };
            TissueType tuberCiner = new TissueType() { Name = "Tuber cinereum", IsSelectable = true };
            TissueType tuberNuc = new TissueType() { Name = "Tuberal nucleus", IsSelectable = true };
            TissueType tuberMammNuc = new TissueType() { Name = "Tuberomammillary nucleus", IsSelectable = true };
            TissueType tuberRegion = new TissueType() { Name = "Tuberal region", IsSelectable = true };
            TissueType mammBodies = new TissueType() { Name = "Mammilary bodies", IsSelectable = true };
            TissueType mammNuc = new TissueType() { Name = "Mammilary nucleus", IsSelectable = true };
            TissueType subthal = new TissueType() { Name = "Subthalamus", IsSelectable = true };
            TissueType thalNuc = new TissueType() { Name = "Thalamic nucleus", IsSelectable = true };
            TissueType zonaIncerta = new TissueType() { Name = "Zona incerta", IsSelectable = true };
            TissueType pituitary = new TissueType() { Name = "Pituitary gland", IsSelectable = true };
            TissueType neuroHypo = new TissueType() { Name = "Neurohypophysis", IsSelectable = true };
            TissueType intermedPituit = new TissueType() { Name = "Itermediate pituitary", IsSelectable = true };
            TissueType adenoHypo = new TissueType() { Name = "Adenohypophysis", IsSelectable = true };

            TissueType telenceph = new TissueType() { Name = "Telencephalon (cerebrum)", IsSelectable = false };
            TissueType whiteMatter = new TissueType() { Name = "White matter", IsSelectable = false };
            TissueType coronaRadiata = new TissueType() { Name = "Corona radiata", IsSelectable = true };
            TissueType internCaps = new TissueType() { Name = "Internal capsule", IsSelectable = true };
            TissueType externCaps = new TissueType() { Name = "External capsule", IsSelectable = true };
            TissueType extremeCaps = new TissueType() { Name = "Extreme capsule", IsSelectable = true };
            TissueType arcuateFasc = new TissueType() { Name = "Arcuate fasciculus", IsSelectable = true };
            TissueType uncinateFasc = new TissueType() { Name = "Uncinate fasciculus", IsSelectable = true };
            TissueType subcortical = new TissueType() { Name = "Subcortical", IsSelectable = false };
            TissueType hippocamp = new TissueType() { Name = "Hippocampus", IsSelectable = true };
            TissueType dentGyr = new TissueType() { Name = "Dentate gyrus", IsSelectable = true };
            TissueType cornuAmmon = new TissueType() { Name = "Cornu ammonis", IsSelectable = true };
            TissueType ca1 = new TissueType() { Name = "CA area 1", IsSelectable = true };
            TissueType ca2 = new TissueType() { Name = "CA area 2", IsSelectable = true };
            TissueType ca3 = new TissueType() { Name = "CA area 3", IsSelectable = true };
            TissueType ca4 = new TissueType() { Name = "CA area 4", IsSelectable = true };
            TissueType amygdala = new TissueType() { Name = "Amygdala", IsSelectable = true };
            TissueType amygCentNuc = new TissueType() { Name = "Central nucleus", IsSelectable = true };
            TissueType amygMedNuc = new TissueType() { Name = "Medial nucleus", IsSelectable = true };
            TissueType amygCortNucs = new TissueType() { Name = "Cortical nuclei", IsSelectable = true };
            TissueType basoMedNucs = new TissueType() { Name = "Basomedial nuclei", IsSelectable = true };
            TissueType amygLatNucs = new TissueType() { Name = "Lateral nuclei", IsSelectable = true };
            TissueType basoLatNucs = new TissueType() { Name = "Basolateral nuclei", IsSelectable = true };
            TissueType claustrum = new TissueType() { Name = "Claustrum", IsSelectable = true };
            TissueType basalGanglia = new TissueType() { Name = "Basal ganglia", IsSelectable = true };
            TissueType striatum = new TissueType() { Name = "Striatum", IsSelectable = true };
            TissueType dorsStriat = new TissueType() { Name = "Dorsal striatum", IsSelectable = true };
            TissueType putamen = new TissueType() { Name = "Putamen", IsSelectable = true };
            TissueType caudateNuc = new TissueType() { Name = "Caudate nucleus", IsSelectable = true };
            TissueType ventStriat = new TissueType() { Name = "Ventral striatum", IsSelectable = true };
            TissueType nucAccumbens = new TissueType() { Name = "Nucleus accumbens", IsSelectable = true };
            TissueType olfactTuber = new TissueType() { Name = "Olfactory tubercle", IsSelectable = true };
            TissueType globusPallidus = new TissueType() { Name = "Globus pallidus", IsSelectable = true };
            TissueType nucLenti = new TissueType() { Name = "Nucleus lentiformis", IsSelectable = true };
            TissueType subthalNuc = new TissueType() { Name = "Subthalamic nucleus", IsSelectable = true };
            TissueType basalForebrain = new TissueType() { Name = "Basal forebrain", IsSelectable = false };
            TissueType antPerfSub = new TissueType() { Name = "Anterior perforated substance", IsSelectable = true };
            TissueType subInnom = new TissueType() { Name = "Substantia innominata", IsSelectable = true };
            TissueType nucBasalis = new TissueType() { Name = "Nucleus basalis", IsSelectable = true };
            TissueType brocaBand = new TissueType() { Name = "Diagonal band of Broca", IsSelectable = true };
            TissueType medSeptalNuc = new TissueType() { Name = "Medial septal nuclei", IsSelectable = true };
            TissueType rhinenceph = new TissueType() { Name = "Rhinencephalon (paleopallium)", IsSelectable = false };
            TissueType olfactBulb = new TissueType() { Name = "Olfactory bulb", IsSelectable = true };
            TissueType piriCortex = new TissueType() { Name = "Piriform cortex", IsSelectable = true };
            TissueType antOlfactNuc = new TissueType() { Name = "Anterior olfactory nucleus", IsSelectable = true };
            TissueType antComm = new TissueType() { Name = "Anterior commisure", IsSelectable = true };
            TissueType uncus = new TissueType() { Name = "Uncus", IsSelectable = true };
            TissueType cerebCort = new TissueType() { Name = "Cerebral cortex (neopallium)", IsSelectable = false };
            TissueType frontalLobe = new TissueType() { Name = "Frontal lobe", IsSelectable = false };
            TissueType frontCorts = new TissueType() { Name = "Cortices", IsSelectable = false };
            TissueType motorCort1 = new TissueType() { Name = "Primary motor cortex (precentral gyrus, M1)", IsSelectable = true };
            TissueType motorCort2 = new TissueType() { Name = "Supplementary motor cortex", IsSelectable = true };
            TissueType preMotorCort = new TissueType() { Name = "Premotor cortex", IsSelectable = true };
            TissueType preFrontCort = new TissueType() { Name = "Prefrontal cortex", IsSelectable = true };
            TissueType frontGyri = new TissueType() { Name = "Gyri", IsSelectable = false };
            TissueType supFrontGyr = new TissueType() { Name = "Superior frontal gyrus", IsSelectable = true };
            TissueType midFrontGyr = new TissueType() { Name = "Middle frontal gyrus", IsSelectable = true };
            TissueType infFrontGyr = new TissueType() { Name = "Inferior frontal gyrus", IsSelectable = true };
            TissueType frontBrodmann = new TissueType() { Name = "Brodmann areas", IsSelectable = false };
            TissueType parietLobe = new TissueType() { Name = "Parietal lobe", IsSelectable = false };
            TissueType parietCorts = new TissueType() { Name = "Cortices", IsSelectable = false };
            TissueType sensCort1 = new TissueType() { Name = "Primary somatosensory cortex (postcentral gyrus, S1)", IsSelectable = true };
            TissueType sensCort2 = new TissueType() { Name = "Secondary somatosensory cortex (S2)", IsSelectable = true };
            TissueType postParietCort = new TissueType() { Name = "Posterior parietal cortex", IsSelectable = true };
            TissueType precuneus = new TissueType() { Name = "Precuneus", IsSelectable = true };
            TissueType parietBrodmann = new TissueType() { Name = "Brodmann areas", IsSelectable = false };
            TissueType occipLobe = new TissueType() { Name = "Occipital lobe", IsSelectable = false };
            TissueType occipCorts = new TissueType() { Name = "Cortices", IsSelectable = false };
            TissueType visCort1 = new TissueType() { Name = "Primary visual cortex (V1)", IsSelectable = true };
            TissueType visCort2 = new TissueType() { Name = "V2", IsSelectable = true };
            TissueType visCort3 = new TissueType() { Name = "V3", IsSelectable = true };
            TissueType visCort4 = new TissueType() { Name = "V4", IsSelectable = true };
            TissueType visCort5 = new TissueType() { Name = "V5 / MT", IsSelectable = true };
            TissueType latOccipGyr = new TissueType() { Name = "Lateral occipital gyrus", IsSelectable = true };
            TissueType cuneus = new TissueType() { Name = "Cuneus", IsSelectable = true };
            TissueType occipBrodmann = new TissueType() { Name = "Brodmann areas", IsSelectable = false };
            TissueType tempLobe = new TissueType() { Name = "Temporal lobe", IsSelectable = false };
            TissueType tempCorts = new TissueType() { Name = "Cortices", IsSelectable = false };
            TissueType auditCort1 = new TissueType() { Name = "Primary auditory cortex (A1)", IsSelectable = true };
            TissueType auditCort2 = new TissueType() { Name = "Secondary auditory cortex (A1)", IsSelectable = true };
            TissueType infTempCort = new TissueType() { Name = "Inferior temporal cortex", IsSelectable = true };
            TissueType postInfTempCort = new TissueType() { Name = "Posterior inferior temporal cortex", IsSelectable = true };
            TissueType tempGyri = new TissueType() { Name = "Gyri", IsSelectable = false };
            TissueType supTempGyr = new TissueType() { Name = "Superior temporal gyrus", IsSelectable = true };
            TissueType midTempGyr = new TissueType() { Name = "Middle temporal gyrus", IsSelectable = true };
            TissueType infTempGyr = new TissueType() { Name = "Inferior temporal gyrus", IsSelectable = true };
            TissueType fusiGyr = new TissueType() { Name = "Fusiform gyrus", IsSelectable = true };
            TissueType paraHippoGyr = new TissueType() { Name = "Parahippocampal gyrus", IsSelectable = true };
            TissueType tempBrodmann = new TissueType() { Name = "Brodmann areas", IsSelectable = false };
            TissueType mst = new TissueType() { Name = "Medial superior temporal area (MST)", IsSelectable = true };
            TissueType insularCort = new TissueType() { Name = "Insular cortex", IsSelectable = true };
            TissueType cingulateCort = new TissueType() { Name = "Cingulate cortex", IsSelectable = true };
            TissueType antCingulate = new TissueType() { Name = "Anterior cingulate", IsSelectable = true };
            TissueType postCingulate = new TissueType() { Name = "Posterior cingulate", IsSelectable = true };
            TissueType retroSplenCort = new TissueType() { Name = "Retrosplenial cortex", IsSelectable = true };
            TissueType indusGris = new TissueType() { Name = "Indusium griseum", IsSelectable = true };
            TissueType subgenArea = new TissueType() { Name = "Subgenual area", IsSelectable = true };
            TissueType cingulateBrodmann = new TissueType() { Name = "Brodmann areas", IsSelectable = false };

            TissueType[] ba = new TissueType[53];
            for (int a = 1; a <= 52; ++a)
                ba[a] = new TissueType() { Name = $"Brodmann area {a}", IsSelectable = true };

            TissueType nervs = new TissueType() { Name = "Nerves", IsSelectable = false };
            TissueType brainstem = new TissueType() { Name = "Brainstem", IsSelectable = false };
            TissueType cranialNervs = new TissueType() { Name = "Cranial nerves", IsSelectable = false };
            TissueType cn0 = new TissueType() { Name = "Terminal (0)", IsSelectable = true };
            TissueType cn1 = new TissueType() { Name = "Olfactory (I)", IsSelectable = true };
            TissueType cn2 = new TissueType() { Name = "Optic (II)", IsSelectable = true };
            TissueType cn3 = new TissueType() { Name = "Oculomotor (III)", IsSelectable = true };
            TissueType cn4 = new TissueType() { Name = "Trochlear (IV)", IsSelectable = true };
            TissueType cn5 = new TissueType() { Name = "Trigeminal (V)", IsSelectable = true };
            TissueType cn6 = new TissueType() { Name = "Abducens (VI)", IsSelectable = true };
            TissueType cn7 = new TissueType() { Name = "Facial (VII)", IsSelectable = true };
            TissueType cn8 = new TissueType() { Name = "Vestibulocochlear (VIII)", IsSelectable = true };
            TissueType cn9 = new TissueType() { Name = "Glossopharyngeal (IX)", IsSelectable = true };
            TissueType cn10 = new TissueType() { Name = "Vagus (X)", IsSelectable = true };
            TissueType cn11 = new TissueType() { Name = "Accessory (XI)", IsSelectable = true };
            TissueType cn12 = new TissueType() { Name = "Hypoglossal (XII)", IsSelectable = true };

            // Create parent-child relationships
            createParentChildAssoc(nervs, brainstem);
            createParentChildAssoc(brainstem, cranialNervs);
            createParentChildAssoc(cranialNervs, cn0, cn1, cn2, cn3, cn4, cn5, cn6, cn7, cn8, cn9, cn10, cn11, cn12);

            createParentChildAssoc(brain, forebrain, midbrain, hindbrain);

            createParentChildAssoc(hindbrain, myelenceph, metenceph);
            createParentChildAssoc(myelenceph, medulla);
            createParentChildAssoc(medulla, medulPyrs, respirCenter, olivary, medulNucs);
            createParentChildAssoc(olivary, infOlivNuc);
            createParentChildAssoc(medulNucs, infSalivNuc, nucAmbig, dorsVagusNuc, hypoGlossNuc, solitaryNuc);
            createParentChildAssoc(metenceph, pons, cerebellum);
            createParentChildAssoc(pons, pontineNucs, ponTegmentum, supOlivComplex, ponsReticForm);
            createParentChildAssoc(pontineNucs, trigeminalSensNuc, trigeminalMotorNuc, abducensNuc, facialNuc, vestibuloCochNuc, supSalivNuc);
            createParentChildAssoc(ponTegmentum, respirCenters, locusCoeruleus, peduncPonNuc, ponLatTegmentNuc, ponReticTegmentNuc);
            createParentChildAssoc(respirCenters, pneumoCenter, apneusticCenter);
            createParentChildAssoc(cerebellum, cerebelPeduncs, cerebelVermis, cerebelHemis, cerebelNucs);
            createParentChildAssoc(cerebelPeduncs, supCerebelPedunc, midCerebelPedunc, infCerebelPedunc);
            createParentChildAssoc(cerebelHemis, cerebelAntLobe, cerebelPostLobe, cerebelFloccLobe);
            createParentChildAssoc(cerebelNucs, fastigNuc, globNuc, embolNuc, dentNuc);

            createParentChildAssoc(midbrain, tectum, pretectum, cerebPedunc, mesCranialNucs);
            createParentChildAssoc(tectum, corpQuad);
            createParentChildAssoc(corpQuad, supCollic, infCollic);
            createParentChildAssoc(cerebPedunc, tegmentum, subNigra, crusCereb, interPeduncNuc);
            createParentChildAssoc(tegmentum, ventTegmentArea, redNuc, midReticForm, periAqueGray);
            createParentChildAssoc(subNigra, parsCompact, parsRetic);
            createParentChildAssoc(mesCranialNucs, oculomotorNuc, trochNuc);

            createParentChildAssoc(forebrain, dienceph, telenceph);
            createParentChildAssoc(dienceph, epithal, thalamus, hypothal, subthal, pituitary);
            createParentChildAssoc(epithal, pineal, habenNuc, striaMedul, taenThal);
            createParentChildAssoc(thalamus, thalAntNucs, thalMedNucs, thalLatNucs, thalVentNucs, metathal, thalReticNuc);
            createParentChildAssoc(thalAntNucs, thalAntVentNuc, thalAntDorsNuc, thalAntMedNuc);
            createParentChildAssoc(thalMedNucs, thalMedDorsNuc, thalMidNucs, intralamNucs);
            createParentChildAssoc(thalMidNucs, paraVentricNuc, paratenNuc, reuniensNuc, rhomboNuc, subFascNuc);
            createParentChildAssoc(intralamNucs, centMedNuc, paraCentNuc, centLatNuc, paraFascNuc, thalCentMedNuc);
            createParentChildAssoc(thalLatNucs, thalLatDorsNuc, thalLatPostNuc, pulvinar);
            createParentChildAssoc(thalVentNucs, thalVentAntNuc, thalVentLatNuc, thalVentPostLatNuc, thalVentPostMedNuc);
            createParentChildAssoc(metathal, medGenic, latGenic);
            createParentChildAssoc(hypothal, antHypothal, tubHypothal, postHypothal, opticChias, subFornOrgan, periVentricNuc, pituitaryStalk, tuberCiner, tuberRegion, mammBodies, mammNuc, hypothalLatNuc);
            createParentChildAssoc(antHypothal, medPreOptNuc, supraChiasNuc, paraVentricNuc, supraOptNuc, antHypothalNuc, latPreOptNuc, midPreOptNuc, periVentPreOptNuc);
            createParentChildAssoc(tubHypothal, hypothalDorsMedNuc, hypothalVentMedNuc, arcuateNuc, latTubNucs);
            createParentChildAssoc(postHypothal, hypothalPostNuc);
            createParentChildAssoc(tuberCiner, tuberNuc, tuberMammNuc);
            createParentChildAssoc(subthal, thalNuc, zonaIncerta);
            createParentChildAssoc(pituitary, neuroHypo, intermedPituit, adenoHypo);
            createParentChildAssoc(telenceph, whiteMatter, subcortical, rhinenceph, cerebCort);
            createParentChildAssoc(whiteMatter, coronaRadiata, internCaps, externCaps, extremeCaps, arcuateFasc, uncinateFasc);
            createParentChildAssoc(subcortical, hippocamp, amygdala, claustrum, basalGanglia, basalForebrain);
            createParentChildAssoc(hippocamp, dentGyr, cornuAmmon);
            createParentChildAssoc(cornuAmmon, ca1, ca2, ca3, ca4);
            createParentChildAssoc(amygdala, amygCentNuc, amygMedNuc, amygCortNucs, basoMedNucs, amygLatNucs, basoLatNucs);
            createParentChildAssoc(basalGanglia, striatum, globusPallidus, subthalNuc, nucLenti);
            createParentChildAssoc(striatum, dorsStriat, ventStriat);
            createParentChildAssoc(dorsStriat, putamen, caudateNuc);
            createParentChildAssoc(ventStriat, nucAccumbens, olfactTuber);
            createParentChildAssoc(basalForebrain, antPerfSub, subInnom, nucBasalis, brocaBand, medSeptalNuc);
            createParentChildAssoc(rhinenceph, olfactBulb, piriCortex, antOlfactNuc, antComm, uncus);
            createParentChildAssoc(cerebCort, frontalLobe, parietLobe, occipLobe, tempLobe, insularCort, cingulateCort);
            createParentChildAssoc(frontalLobe, frontCorts, frontGyri, frontBrodmann);
            createParentChildAssoc(frontCorts, motorCort1, motorCort2, preMotorCort, preFrontCort);
            createParentChildAssoc(frontGyri, supFrontGyr, midFrontGyr, infFrontGyr);
            createParentChildAssoc(frontBrodmann, ba[4], ba[6], ba[8], ba[9], ba[10], ba[11], ba[12], ba[24], ba[25], ba[32], ba[33], ba[44], ba[45], ba[46], ba[47]);
            createParentChildAssoc(parietLobe, parietCorts, parietBrodmann, precuneus);
            createParentChildAssoc(parietCorts, sensCort1, sensCort2, postParietCort);
            createParentChildAssoc(parietBrodmann, ba[1], ba[2], ba[3], ba[5], ba[7], ba[23], ba[26], ba[29], ba[31], ba[39], ba[40]);
            createParentChildAssoc(occipLobe, occipCorts, latOccipGyr, cuneus, occipBrodmann);
            createParentChildAssoc(occipCorts, visCort1, visCort2, visCort3, visCort4, visCort5);
            createParentChildAssoc(occipBrodmann, ba[17], ba[18], ba[19]);
            createParentChildAssoc(tempLobe, tempCorts, tempGyri, tempBrodmann, mst);
            createParentChildAssoc(tempCorts, auditCort1, auditCort2, infTempCort, postInfTempCort);
            createParentChildAssoc(tempGyri, supTempGyr, midTempGyr, infTempGyr, fusiGyr, paraHippoGyr);
            createParentChildAssoc(tempBrodmann, ba[20], ba[21], ba[22], ba[27], ba[34], ba[35], ba[36], ba[37], ba[38], ba[41], ba[42]);
            createParentChildAssoc(cingulateCort, antCingulate, postCingulate, retroSplenCort, indusGris, subgenArea, cingulateBrodmann);

            // Wrap these TissueTypes in a list and return it
            return new List<TissueType>() { brain, nervs };
        }
        private void createParentChildAssoc(TissueType parent, params TissueType[] children) {
            foreach (TissueType child in children) {
                child.Parent = parent;
                parent.Children.Add(child);
            }
        }

    }

}
