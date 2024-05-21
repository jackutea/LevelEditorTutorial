namespace LevelEditorTutorial {

    // 存储全游戏的上下文, 即所有内存数据
    public class Context {

        // ==== 实体 ====
        public TerrainRepository terrainRepository;
        public PropRepository propRepository;

        // ==== 基础设施-模块 ====
        public AssetManager assetManager;
        // 音效/相机/特效

        // ==== 服务 ====
        public IDService idService;

        public Context() {

            terrainRepository = new TerrainRepository();
            propRepository = new PropRepository();

            assetManager = new AssetManager();

            idService = new IDService();

        }

    }

}